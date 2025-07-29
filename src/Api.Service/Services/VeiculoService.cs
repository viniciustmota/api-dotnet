using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Veiculo;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.Field;
using Api.Domain.Interfaces.Services.Veiculo;
using AutoMapper;

namespace Api.Service.Services
{
    public class VeiculoService : BaseService<
        VeiculoEntity,
        VeiculoDto,
        VeiculoDtoCreate,
        VeiculoDtoUpdate,
        Guid,
        VeiculoDto>,
        IVeiculoService
    {
        public VeiculoService(IRepository<VeiculoEntity, Guid> repository, IMapper mapper, IMetadataService metadataService, IServiceProvider serviceProvider)
            : base(repository, mapper, metadataService, serviceProvider)
        {
        }
    }
}