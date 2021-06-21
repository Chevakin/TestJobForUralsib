using AutoMapper;
using TestJobForUralsib.Domain.Models;

namespace TestJobForUralsib.Domain.DTOs.mapping.Profiles
{
    public class CustomerExtraInformationProfile : Profile
    {
        public CustomerExtraInformationProfile()
        {
            CreateMap<CustomerExtraInformation, CustomerInformationDto>();
        }
    }
}
