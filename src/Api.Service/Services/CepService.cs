using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Cep;
using Api.Domain.Interfaces.Services.Field;

using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class CepService : BaseService<
        CepEntity,
        CepDto,
        CepDtoCreate,
        CepDtoUpdate,
        Guid,
        CepDto>,
        ICepService
    {
        private readonly ICepRepository _repository;
        private readonly IMapper _mapper;

        public CepService(ICepRepository repository, IMapper mapper, IMetadataService metadataService, IServiceProvider serviceProvider)
            : base(repository, mapper, metadataService, serviceProvider)  // passe repository aqui
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CepDto> GetByCep(string cep)
        {
            var entity = await _repository.SelectAsync(cep);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDtoVisualizacao> GetVisualizacao(string cep)
        {
            var entity = await _repository.SelectAsync(cep);

            return new CepDtoVisualizacao
            {
                Cep = entity.Cep,
                Logradouro = entity.Logradouro,
                Numero = entity.Numero,
                Municipio = entity.Municipio?.Nome,
                UfSigla = entity.Municipio?.Uf?.Sigla
            };
        }
    }
}