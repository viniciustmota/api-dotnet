using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Bogus;

namespace Api.Service.Test.Cep
{
    public class CepTestes
    {
        private Faker _faker;

        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string CepAlterado { get; private set; }
        public string LogradouroAlterado { get; private set; }
        public string NumeroAlterado { get; private set; }
        public Guid IdMunicipio { get; private set; }
        public Guid IdCep { get; private set; }


        public List<CepDto> listaDto = new List<CepDto>();
        public CepDto cepDto;
        public CepDtoCreate cepDtoCreate;
        public CepDtoCreateResult cepDtoCreateResult;
        public CepDtoUpdate cepDtoUpdate;
        public CepDtoUpdateResult cepDtoUpdateResult;

        public CepTestes()
        {
            _faker = new Faker("pt_BR");
            IdMunicipio = Guid.NewGuid();
            IdCep = Guid.NewGuid();
            Cep = _faker.Random.Number(10000000, 99999999).ToString();
            Numero = _faker.Random.Number(1, 10000).ToString();
            Logradouro = _faker.Address.StreetName();
            CepAlterado =  _faker.Random.Number(10000000, 99999999).ToString();
            NumeroAlterado =  _faker.Random.Number(1, 10000).ToString();
            LogradouroAlterado = _faker.Address.StreetName();
            
            for (int i = 0; i < 10; i++)
            {
                var dto = new CepDto()
                {
                    Id = Guid.NewGuid(),
                    Cep = _faker.Random.Number(10000000, 99999999).ToString(),
                    Logradouro = _faker.Address.StreetAddress(),
                    Numero = _faker.Random.Number(1, 10000).ToString(),
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioDtoCompleto
                    {
                        Id = IdMunicipio,
                        Nome = _faker.Address.City(),
                        CodIBGE = _faker.Random.Number(1, 10000),
                        UfId = Guid.NewGuid(),
                        Uf = new UfDto
                        {
                            Id = Guid.NewGuid(),
                            Nome = _faker.Address.State(),
                            Sigla = _faker.Address.StateAbbr()
                        }
                    }
                };
                listaDto.Add(dto);
            }

            cepDto = new CepDto
            {
                Id = IdCep,
                Cep =  Cep,
                Logradouro = Logradouro,
                Numero = Numero,
                MunicipioId = IdMunicipio,
                Municipio = new MunicipioDtoCompleto
                {
                    Id = IdMunicipio,
                    Nome = _faker.Address.City(),
                    CodIBGE = _faker.Random.Number(1, 10000),
                    UfId = Guid.NewGuid(),
                    Uf = new UfDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = _faker.Address.State(),
                        Sigla = _faker.Address.StateAbbr()
                    }
                }
            };

            cepDtoCreate = new CepDtoCreate
            {
                Cep = Cep,
                Logradouro = Logradouro,
                Numero = Numero,
                MunicipioId = IdMunicipio
            };

            cepDtoCreateResult = new CepDtoCreateResult
            {
                Id = IdCep,
                Cep = Cep,
                Logradouro = Logradouro,
                Numero = Numero,
                MunicipioId = IdMunicipio,
                CreateAt = DateTime.UtcNow
            };

            cepDtoUpdate = new CepDtoUpdate
            {
                Id = IdCep,
                Cep = CepAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioId = IdMunicipio
            };

            cepDtoUpdateResult = new CepDtoUpdateResult
            {
                Id = IdCep,
                Cep = CepAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioId = IdMunicipio,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}