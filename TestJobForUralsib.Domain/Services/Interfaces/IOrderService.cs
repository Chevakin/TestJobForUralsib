using System.Collections.Generic;
using TestJobForUralsib.Domain.DTOs;

namespace TestJobForUralsib.Domain.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> Get(int id);
    }
}
