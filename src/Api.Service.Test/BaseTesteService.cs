﻿using Api.CrossCutting.Mappings;
using AutoMapper;

namespace Api.Service.Test;

public abstract class BaseTesteService
{
    public IMapper Mapper { get; set; }
    public BaseTesteService()
    {
        Mapper = new AutoMapperFixture().GetMapper();
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToEntityProfile());
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
            });

            return config.CreateMapper();
        }
        public void Dispose()
        {

        }
    }
}
