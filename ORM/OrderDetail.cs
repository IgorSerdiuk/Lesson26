using System;

namespace ORM
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment{ get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
