using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using TestJobForUralsib.Domain.Data;
using TestJobForUralsib.Domain.DTOs;
using TestJobForUralsib.Domain.Services.Interfaces;

namespace TestJobForUralsib.Domain.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly TestJobForUralsibDbContext context;
        private readonly IMapper mapper;

        public CustomersService(TestJobForUralsibDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<SimpleCustomerDto> Get()
        {
            return context.Customers
                .ProjectTo<SimpleCustomerDto>(mapper.ConfigurationProvider)
                .ToArray();
        }
    }
}
