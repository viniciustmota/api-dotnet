using Api.Domain.Dtos;
using Api.Domain.Dtos.Metadata;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.Field;
using Api.Domain.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class BaseService<TEntity, TDto, TDtoCreate, TDtoUpdate, TId, TDtoCompleto> : IBaseAppService<TEntity, TDto, TDtoCreate, TDtoUpdate, TId, TDtoCompleto, TEntity>
        where TEntity : BaseEntity
        where TDto : class
        where TDtoCreate : class
        where TDtoUpdate : class
    {
        private DbSet<TEntity> _dataset;
        protected readonly IRepository<TEntity, TId> _repository;
        protected readonly IMapper _mapper;
        protected readonly IMetadataService _metadataService;
        protected readonly IServiceProvider _serviceProvider;

        public BaseService(
            IRepository<TEntity, TId> repository,
            IMapper mapper,
            IMetadataService metadataService,
            IServiceProvider serviceProvider)
        {
            _repository = repository;
            _mapper = mapper;
            _metadataService = metadataService;
            _serviceProvider = serviceProvider;
        }

        public virtual async Task<TDto> Get(TId id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<TDtoCompleto> GetCompleteById(TId id)
        {
            // Opcional: sobrescrever nas services concretas se quiser buscar entidade completa com relacionamentos.
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<TDtoCompleto>(entity);
        }

        public virtual async Task<PagedResultDto<TDto>> GetAll(
    int page,
    int pageSize,
    string? search = null,
    string? order = null,
    string? direction = null,
    string? filter = null)
{
    var query = await _repository.GetQueryable(); // <-- aguarda aqui

    if (!string.IsNullOrWhiteSpace(search))
    {
        query = query.Where("true"); // ainda precisa implementar lógica real de busca
    }

    if (!string.IsNullOrEmpty(order))
    {
        var orderString = direction?.ToLower() == "descending" ? $"{order} descending" : order;
        query = query.OrderBy(orderString);
    }

    var total = await query.CountAsync(); // agora funciona

    var items = await query
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    var dtos = _mapper.Map<IEnumerable<TDto>>(items);

    return new PagedResultDto<TDto>
    {
        Items = dtos,
        Page = page,
        PageSize = pageSize,
        Total = total,
        HasNext = page * pageSize < total
    };
}


        public virtual async Task<MetadataDto> GetMetadata()
        {
            var metadata = new MetadataDto
            {
                Version = 1,
                Title = typeof(TEntity).Name,
                KeepFilters = false,
                Fields = await _metadataService.GenerateMetadata<TDto>(_serviceProvider)
            };

            return metadata;
        }

        public virtual async Task<TDto> Post(TDtoCreate dtoCreate)
        {
            var entity = _mapper.Map<TEntity>(dtoCreate);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<TDto>(result);
        }

        public virtual async Task<TDto> Put(TDtoUpdate dtoUpdate)
        {
            var entity = _mapper.Map<TEntity>(dtoUpdate);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<TDto>(result);
        }

        public virtual async Task<bool> Delete(TId id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<int> DeleteBatch(List<TId> ids)
        {
            int deletedCount = 0;
            foreach (var id in ids)
            {
                var deleted = await Delete(id);
                if (deleted)
                    deletedCount++;
            }
            return deletedCount;
        }

    }
}
