using System;

namespace TestJobForUralsib.Domain.DTOs
{
    public class OrderDto
    {
        public int ID;
        public DateTime? Date;
        public decimal AmountMoney;
        public byte[] Photo;
        public SimpleCustomerDto Customer;
    }
}
