using System.Collections.Generic;
using TestJobForUralsib.Domain.DTOs;

namespace TestJobForUralsib.Domain.Services.Interfaces
{
    public interface ICustomersService
    {
        IEnumerable<SimpleCustomerDto> Get();
    }
}
