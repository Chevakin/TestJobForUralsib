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

        public Customer(string name, string surname, string patronimyc, CustomerExtraInformation information)
            : this(name, surname, information)
        {
            Patronymic = patronimyc;
        }

        public Customer(string name, string surname, CustomerExtraInformation information)
            : this()
        {
            Name = name;
            Surname = surname;
            Information = information;
        }

        private Customer()
        {
            Orders = new HashSet<Order>();
        }
    }
}
