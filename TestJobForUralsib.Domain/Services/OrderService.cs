using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using TestJobForUralsib.Domain.Data;
using TestJobForUralsib.Domain.DTOs;
using TestJobForUralsib.Domain.Services.Interfaces;

namespace TestJobForUralsib.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly TestJobForUralsibDbContext context;
        private readonly IMapper mapper;

        public OrderService(TestJobForUralsibDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<OrderDto> Get(int id)
        {
            return context.Orders
                .Where(o => o.Customer.ID == id)
                .ProjectTo<OrderDto>(mapper.ConfigurationProvider)
                .ToArray();
        }
    }
}
