using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Bogus;

namespace Api.Service.Test.Municipio
{
    public class MunicipioTestes
    {
        private Faker _faker;
        public string NomeMunicipio { get; private set; }
        public int CodigoIBGEMunicipio { get; private set; }
        public string NomeMunicipioAlterado { get; private set; }
        public int CodigoIBGEMunicipioAlterado { get; private set; }
        public Guid IdMunicipio { get; private set; }
        public Guid IdUf { get; private set; }


        public List<MunicipioDto> listaDto = new List<MunicipioDto>();
        public MunicipioDto municipioDto;
        public MunicipioDtoCompleto municipioDtoCompleto;
        public MunicipioDtoCreate municipioDtoCreate;
        public MunicipioDtoCreateResult municipioDtoCreateResult;
        public MunicipioDtoUpdate municipioDtoUpdate;
        public MunicipioDtoUpdateResult municipioDtoUpdateResult;

        public MunicipioTestes()
        {
            _faker = new Faker("pt_BR");
            IdMunicipio = Guid.NewGuid();
            NomeMunicipio = _faker.Address.StreetName();
            CodigoIBGEMunicipio = _faker.Random.Number(1, 10000);
            NomeMunicipioAlterado = _faker.Address.StreetName();
            CodigoIBGEMunicipioAlterado = _faker.Random.Number(1, 10000);
            IdUf = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new MunicipioDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = _faker.Name.FullName(),
                    CodIBGE = _faker.Random.Number(1, 10000),
                    UfId = Guid.NewGuid()
                };
                listaDto.Add(dto);
            }

            municipioDto = new MunicipioDto
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodigoIBGEMunicipio,
                UfId = IdUf,
            };

            municipioDtoCompleto = new MunicipioDtoCompleto
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodigoIBGEMunicipio,
                UfId = IdUf,
                Uf = new UfDto
                {
                    Id = Guid.NewGuid(),
                    Nome = _faker.Address.State(),
                    Sigla = _faker.Address.StateAbbr()
                }
            };

            municipioDtoCreate = new MunicipioDtoCreate
            {
                Nome = NomeMunicipio,
                CodIBGE = CodigoIBGEMunicipio,
                UfId = IdUf,
            };

            municipioDtoCreateResult = new MunicipioDtoCreateResult
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodigoIBGEMunicipio,
                UfId = IdUf,
                CreateAt = DateTime.UtcNow
            };

            municipioDtoUpdate = new MunicipioDtoUpdate
            {
                Id = IdMunicipio,
                Nome = NomeMunicipioAlterado,
                CodIBGE = CodigoIBGEMunicipioAlterado,
                UfId = IdUf,
            };

            municipioDtoUpdateResult = new MunicipioDtoUpdateResult
            {
                Id = IdMunicipio,
                Nome = NomeMunicipioAlterado,
                CodIBGE = CodigoIBGEMunicipioAlterado,
                UfId = IdUf,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}