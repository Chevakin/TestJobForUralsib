using AutoMapper;
using System;
using TestJobForUralsib.Domain.DTOs.mapping.Profiles;

namespace TestJobForUralsib.Domain.DTOs.mapping
{
    public static class InitializeAutomapper
    {
        public static Mapper GetInstance(IServiceProvider serviceProvider)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomerProfile>();
            });

            return new Mapper(config);
        }
    }
}
