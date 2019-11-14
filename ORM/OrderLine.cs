namespace ORM
{
    public class OrderLine
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
