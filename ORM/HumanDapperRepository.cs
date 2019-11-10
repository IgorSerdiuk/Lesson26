using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace ORM
{
    public class HumanDapperRepository : IHumanRepository
    {
        private readonly string _connectionString;
        public HumanDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Human GetById(int id)
        {
            var sql = $"SELECT * FROM Humans h INNER JOIN Shoes s on s.Id = h.ShoesId WHERE h.Id = {id};";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Human,Shoes,Human>(sql,(human,shoes) =>
                {
                    human.Shoes = shoes;

                    return human;
                });
                connection.Close();

                return result.FirstOrDefault();
            };
        }

        public void Update(Human human)
        {
            var sql = $"UPDATE Humans SET FirstName = '{human.FirstName}', LastName = '{human.LastName}', FootSize = {human.FootSize} WHERE Id = {human.Id}";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Execute(sql);
                connection.Close();
            };
        }

        public void Delete(Human human)
        {
            var sql = $"DELETE FROM Humans WHERE Id = {human.Id}";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Execute(sql);
                connection.Close();
            };
        }

        public void Create(Human human)
        {
            var sql = $"INSERT INTO Humans (FirstName, LastName, Footsize) OUTPUT INSERTED.Id VALUES ('{human.FirstName}','{human.LastName}',{human.FootSize});";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var insertedId = (int)connection.ExecuteScalar(sql);
                connection.Close();

                human.Id = insertedId;
            };
        }
    }
}
