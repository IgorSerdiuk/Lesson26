using System;

namespace ORM
{
    public class Profile
    {
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
