using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using TestJobForUralsib.Domain.Data;
using TestJobForUralsib.Domain.DTOs;
using TestJobForUralsib.Domain.Models;
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

        public void Create(DateTime date, decimal amountMoney, byte[] photo, int customerId)
        {
            var order = new Order(amountMoney, date, photo);

            context.Customers
                .Find(customerId)
                .Orders
                .Add(order);

            context.SaveChanges();
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
