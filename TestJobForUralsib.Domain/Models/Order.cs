using System;

namespace TestJobForUralsib.Domain.Models
{
    public class Order
    {
        public int ID { get; set; }

        public DateTime? Date { get; set; }

        public decimal AmountMoney { get; set; }

        public byte[] Photo { get; set; }

        public Customer Customer { get; set; }

        public Order(decimal amountMoney, DateTime? date = null, byte[] photo = null, Customer customer = null)
            : this()
        {
            AmountMoney = amountMoney;
            Date = date;
            Photo = photo;
            Customer = customer;
        }
        private Order()
        {
        }
    }
}