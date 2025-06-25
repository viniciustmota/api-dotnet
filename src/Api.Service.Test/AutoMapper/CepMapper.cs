using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;
using Api.Domain.Models;
using Bogus;

namespace Api.Service.Test.AutoMapper
{
    public class CepMapper : BaseTesteService
    {
        private Faker _faker;

        public CepMapper()
        {
            _faker = new Faker("pt_BR");
        }

        [Fact(DisplayName = "É Possível Mapear os Modelos de Cep")]
        public void E_Possivel_Mapear_os_Modelos_Cep()
        {
            var model = new CepModel
            {
                Id = Guid.NewGuid(),
                Cep = _faker.Random.Number(1, 10000).ToString(),
                Logradouro = _faker.Address.StreetName(),
                Numero = "",
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                MunicipioId = Guid.NewGuid()
            };

            var listaEntity = new List<CepEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new CepEntity
                {
                    Id = Guid.NewGuid(),
                    Cep = _faker.Random.Number(1, 10000).ToString(),
                    Logradouro = _faker.Address.StreetName(),
                    Numero = _faker.Random.Number(1, 10000).ToString(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = _faker.Address.City(),
                        CodIBGE = _faker.Random.Number(1, 10000),
                        UfId = Guid.NewGuid(),
                        Uf = new UfEntity
                        {
                            Id = Guid.NewGuid(),
                            Nome = _faker.Address.State(),
                            Sigla = _faker.Address.StateAbbr()
                        }
                    }
                };
                listaEntity.Add(item);
            }

            // Model => Entity
            var entity = Mapper.Map<CepEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Logradouro, model.Logradouro);
            Assert.Equal(entity.Numero, model.Numero);
            Assert.Equal(entity.Cep, model.Cep);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            // Entity para Dto
            var cepDto = Mapper.Map<CepDto>(entity);
            Assert.Equal(cepDto.Id, entity.Id);
            Assert.Equal(cepDto.Logradouro, entity.Logradouro);
            Assert.Equal(cepDto.Numero, entity.Numero);
            Assert.Equal(cepDto.Cep, entity.Cep);

            var cepDtoCompleto = Mapper.Map<CepDto>(listaEntity.FirstOrDefault());
            Assert.Equal(cepDtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(cepDtoCompleto.Cep, listaEntity.FirstOrDefault().Cep);
            Assert.Equal(cepDtoCompleto.Logradouro, listaEntity.FirstOrDefault().Logradouro);
            Assert.Equal(cepDtoCompleto.Numero, listaEntity.FirstOrDefault().Numero);
            Assert.NotNull(cepDtoCompleto.Municipio);
            Assert.NotNull(cepDtoCompleto.Municipio.Uf);

            var listaDto = Mapper.Map<List<CepDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count; i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Cep, listaEntity[i].Cep);
                Assert.Equal(listaDto[i].Logradouro, listaEntity[i].Logradouro);
                Assert.Equal(listaDto[i].Numero, listaEntity[i].Numero);
            }

            var cepDtoCreateResult = Mapper.Map<CepDtoCreateResult>(entity);
            Assert.Equal(cepDtoCreateResult.Id, entity.Id);
            Assert.Equal(cepDtoCreateResult.Cep, entity.Cep);
            Assert.Equal(cepDtoCreateResult.Logradouro, entity.Logradouro);
            Assert.Equal(cepDtoCreateResult.Numero, entity.Numero);
            Assert.Equal(cepDtoCreateResult.CreateAt, entity.CreateAt);

            var cepDtoUpdateResult = Mapper.Map<CepDtoUpdateResult>(entity);
            Assert.Equal(cepDtoUpdateResult.Id, entity.Id);
            Assert.Equal(cepDtoUpdateResult.Cep, entity.Cep);
            Assert.Equal(cepDtoUpdateResult.Logradouro, entity.Logradouro);
            Assert.Equal(cepDtoUpdateResult.Numero, entity.Numero);
            Assert.Equal(cepDtoUpdateResult.UpdateAt, entity.UpdateAt);

            // Dto para Model
            cepDto.Numero = "";
            var cepModel = Mapper.Map<CepModel>(cepDto);
            Assert.Equal(cepModel.Id, cepDto.Id);
            Assert.Equal(cepModel.Cep, cepDto.Cep);
            Assert.Equal(cepModel.Logradouro, cepDto.Logradouro);
            Assert.Equal("S/N", cepModel.Numero);

            var cepDtoCreate = Mapper.Map<CepDtoCreate>(cepModel);
            Assert.Equal(cepDtoCreate.Cep, cepModel.Cep);
            Assert.Equal(cepDtoCreate.Logradouro, cepModel.Logradouro);
            Assert.Equal(cepDtoCreate.Numero, cepModel.Numero);

            var cepDtoUpdate = Mapper.Map<CepDtoUpdate>(cepModel);
            Assert.Equal(cepDtoUpdate.Id, cepModel.Id);
            Assert.Equal(cepDtoUpdate.Cep, cepModel.Cep);
            Assert.Equal(cepDtoUpdate.Logradouro, cepModel.Logradouro);
            Assert.Equal(cepDtoUpdate.Numero, cepModel.Numero);
        }
    }
}