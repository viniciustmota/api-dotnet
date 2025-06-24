using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            #region User
            CreateMap<UserModel, UserEntity>()
                .ReverseMap();
            #endregion

            #region UF
            CreateMap<UfModel, UfEntity>()
                .ReverseMap();
            #endregion

            #region Municipio
            CreateMap<MunicipioModel, MunicipioEntity>()
                .ReverseMap();
            #endregion

            #region CEP
            CreateMap<CepModel, CepEntity>()
                .ReverseMap();
            #endregion
        }
    }
}