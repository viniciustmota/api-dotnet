using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface ICepRepository : IRepository<CepEntity, Guid>
    {
        Task<CepEntity> SelectAsync(string cep);
        Task<CepDtoVisualizacao> GetVisualizacao(string cep);
    }
}