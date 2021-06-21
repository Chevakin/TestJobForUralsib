using AutoMapper;
using TestJobForUralsib.Domain.Models;

namespace TestJobForUralsib.Domain.DTOs.mapping.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, SimpleCustomerDto>();
        }
    }
}
