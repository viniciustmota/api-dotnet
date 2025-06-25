using Api.Domain.Dtos.Uf;
using Bogus;

namespace Api.Service.Test.Uf
{
    public class UfTestes
    {
        private Faker _faker;
        public string Nome { get; private set; }
        public string Sigla { get; private set; }
        public Guid IdUf { get; private set; }
        public List<UfDto> listaUfDto = new List<UfDto>();
        public UfDto ufDto;

        public UfTestes()
        {
            _faker = new Faker("pt_BR");
            IdUf = Guid.NewGuid();
            Sigla = _faker.Address.StateAbbr();
            Nome = _faker.Address.State();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UfDto()
                {
                    Id = Guid.NewGuid(),
                    Sigla = _faker.Address.StateAbbr(),
                    Nome = _faker.Address.State()
                };
                listaUfDto.Add(dto);
            }

            ufDto = new UfDto
            {
                Id = IdUf,
                Sigla = Sigla,
                Nome = Nome
            };
        }
    }
}