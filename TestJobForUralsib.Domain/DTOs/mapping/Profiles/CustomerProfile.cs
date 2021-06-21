using AutoMapper;
using TestJobForUralsib.Domain.Models;
using TestJobForUralsib.Domain.Models.ViewModels;

namespace TestJobForUralsib.Domain.DTOs.mapping.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //Model
            CreateMap<Customer, SimpleCustomerDto>()
                .Include<Customer, CustomerDto>();

            CreateMap<Customer, CustomerDto>();

            //DTO
            CreateMap<CustomerDto, CustomerViewModel>()
                .ForMember(vm => vm.Birthdate, opt => opt.MapFrom(dto => dto.Information == null ? null : dto.Information.Birthdate))
                .ForMember(vm => vm.Email, opt => opt.MapFrom(dto => dto.Information == null ? null : dto.Information.Email))
                .ForMember(vm => vm.Phone, opt => opt.MapFrom(dto => dto.Information == null ? null : dto.Information.Phone));
        }
    }
}
