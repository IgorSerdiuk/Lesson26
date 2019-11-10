namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Humans;Integrated Security=True";

            var humanRepository = new HumanDapperRepository(connectionString);
            var shoesRepository = new ShoesDapperRepository(connectionString);

            var shoes = shoesRepository.GetById(1);
            var hum = humanRepository.GetById(10);
        }
    }
}
