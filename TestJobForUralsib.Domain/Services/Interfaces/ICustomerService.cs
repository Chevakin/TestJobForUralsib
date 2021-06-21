using System;
using System.Collections.Generic;
using TestJobForUralsib.Domain.DTOs;

namespace TestJobForUralsib.Domain.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<SimpleCustomerDto> Get();

        CustomerDto Get(int id);

        void Create(string name, string surname, string patronymic, string email, string phone, DateTime? date);

        void Edit(int id, string name, string surname, string patronymic, string email, string phone, DateTime? date);

        void Delete(int id);
    }
}
