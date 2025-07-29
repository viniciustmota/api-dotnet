using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Dtos.User;
using Api.Domain.Dtos.Veiculo;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            #region User
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>()
                .ReverseMap();
            
            CreateMap<UserDtoCreate, UserEntity>()
                .ReverseMap();
                
            CreateMap<UserDtoUpdate, UserEntity>()
                .ReverseMap();
            #endregion

            #region UF
            CreateMap<UfDto, UfEntity>()
                .ReverseMap();
            #endregion

            #region Municipio
            CreateMap<MunicipioDto, MunicipioEntity>()
                .ReverseMap();

            CreateMap<MunicipioDtoCompleto, MunicipioEntity>()
                .ReverseMap();

            CreateMap<MunicipioDtoCreateResult, MunicipioEntity>()
                .ReverseMap();

            CreateMap<MunicipioDtoUpdateResult, MunicipioEntity>()
                .ReverseMap();

            CreateMap<MunicipioDtoCreate, MunicipioEntity>()
                .ReverseMap();

            CreateMap<MunicipioDtoUpdate, MunicipioEntity>()
                .ReverseMap();
            #endregion

            #region CEP
            CreateMap<CepDto, CepEntity>()
                .ReverseMap();

            CreateMap<CepDtoCreateResult, CepEntity>()
                .ReverseMap();

            CreateMap<CepDtoUpdateResult, CepEntity>()
                .ReverseMap();

            CreateMap<CepDtoCreate, CepEntity>()
                .ReverseMap();
                
            CreateMap<CepDtoUpdate, CepEntity>()
                .ReverseMap();
            #endregion

            #region Veiculo
            CreateMap<VeiculoDtoCreate, VeiculoEntity>();
            CreateMap<VeiculoDtoUpdate, VeiculoEntity>();
            CreateMap<VeiculoDto, VeiculoEntity>().ReverseMap();
            CreateMap<VeiculoDtoCreateResult, VeiculoEntity>().ReverseMap();
            CreateMap<VeiculoDtoUpdateResult, VeiculoEntity>().ReverseMap();
            #endregion
        }
    }
}