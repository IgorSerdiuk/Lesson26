using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace ORM
{
    public class ShoesDapperRepository : IShoesDapperRepository
    {
        private readonly string _connectionString;
        public ShoesDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Shoes GetById(int id)
        {
            var sql = $"SELECT * FROM Shoes s INNER JOIN Humans h on s.Id = h.ShoesId WHERE s.Id = {id};";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var queryResult = connection.Query<Shoes, Human, Shoes>(sql, (shoes, human) =>
                {
                    shoes.Humans.Add(human);

                    return shoes;
                }).ToList();

                var resultEntity = queryResult.FirstOrDefault();
                resultEntity.Humans = queryResult.SelectMany(x => x.Humans).ToList();

                connection.Close();

                return resultEntity;
            };
        }
    }
}
