using System.Collections.Generic;
using TestJobForUralsib.Domain.DTOs;

namespace TestJobForUralsib.Domain.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<SimpleCustomerDto> Get();

        CustomerDto Get(int id);
    }
}
