using System;

namespace TestJobForUralsib.Domain.DTOs
{
    public class CustomerDto : SimpleCustomerDto
    {
        public CustomerInformationDto Information;
    }

    public class CustomerInformationDto
    {
        public string Email;

        public string Phone;

        public DateTime? Birthdate;
    }
}
