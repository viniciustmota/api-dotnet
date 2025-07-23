using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Metadata;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Cep;
using Api.Domain.Interfaces.Services.Field;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class CepService : ICepService
    {
        private ICepRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMetadataService _metadataService;
        private readonly IServiceProvider _serviceProvider;

        public CepService(ICepRepository repository, IMapper mapper,  IMetadataService metadataService, IServiceProvider serviceProvider)
        {
            _repository = repository;
            _mapper = mapper;
            _metadataService = metadataService ?? throw new ArgumentNullException(nameof(metadataService));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task<CepDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDto> Get(string cep)
        {
            var entity = await _repository.SelectAsync(cep);
            return _mapper.Map<CepDto>(entity);
        }

        public async Task<CepDtoCreateResult> Post(CepDtoCreate cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var entity = _mapper.Map<CepEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<CepDtoCreateResult>(result);
        }

        public async Task<CepDtoUpdateResult> Put(CepDtoUpdate cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var entity = _mapper.Map<CepEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<CepDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<MetadataDto> GetMetadata()
        {
           

            var metadata = new MetadataDto
            {
                Version = 1,
                Title = "Ceps",
                KeepFilters = false,
                Fields = await _metadataService.GenerateMetadata<CepDto>(_serviceProvider)
            };

            return metadata;
        }
    }
}