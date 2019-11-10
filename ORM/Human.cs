using System.Collections.Generic;

namespace ORM
{
    public class Human
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FootSize { get; set; }

        public int ShoesId { get; set; }

        public Shoes Shoes { get; set; }
    }

    public class Shoes
    {
        public Shoes()
        {
            Humans = new List<Human>();
        }

        public int Id { get; set; }
        public int Size { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Human> Humans { get; set; }
    }
}
