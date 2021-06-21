using System.Collections.Generic;

namespace TestJobForUralsib.Domain.Models
{
    public class Customer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Patronymic { get; set; }

        public virtual CustomerExtraInformation Information { get; set; }

        public virtual HashSet<Order> Orders { get; set; }

        public Customer(string name, string surname, string patronimyc)
            : this(name, surname)
        {
            Patronymic = patronimyc;
        }

        public Customer(string name, string surname)
            : this()
        {
            Name = name;
            Surname = surname;
        }

        private Customer()
        {
            Orders = new HashSet<Order>();
        }
    }
}
