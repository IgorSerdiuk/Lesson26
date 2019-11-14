using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class Customer
    {
        public int Id { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }
        public string OrdersCount { get; set; }

        public Profile Profile { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
