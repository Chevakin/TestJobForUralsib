using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestJobForUralsib.Domain.Data;
using TestJobForUralsib.Domain.DTOs;
using TestJobForUralsib.Domain.Models;
using TestJobForUralsib.Domain.Services.Interfaces;

namespace TestJobForUralsib.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly TestJobForUralsibDbContext context;
        private readonly IMapper mapper;

        public CustomerService(TestJobForUralsibDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Create(string name, string surname, string patronymic, string email, string phone, DateTime? date)
        {
            var customer = new Customer(name, surname, patronymic)
            {
                Information = new CustomerExtraInformation(phone, email, date)
            };

            context.Add(customer);

            context.SaveChanges();
        }

        public void Edit(int id, string name, string surname, string patronymic, string email, string phone, DateTime? date)
        {
            var customer = context.Customers
                .Include(c => c.Information)
                .First(c => c.ID == id);

            customer.Name = name;
            customer.Surname = surname;
            customer.Patronymic = patronymic;
            customer.Information.Email = email;
            customer.Information.Phone = phone;
            customer.Information.Birthdate = date;

            context.SaveChanges();
        }

        public IEnumerable<SimpleCustomerDto> Get()
        {
            return context.Customers
                .ProjectTo<SimpleCustomerDto>(mapper.ConfigurationProvider)
                .ToArray();
        }

        public CustomerDto Get(int id)
        {
            return context.Customers
                .Where(c => c.ID == id)
                .ProjectTo<CustomerDto>(mapper.ConfigurationProvider)
                .First();
        }
    }
}
