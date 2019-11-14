using System.Collections.Generic;

namespace ORM
{
    public class Order
    {
        public int Id { get; set; }
        public int Price { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
