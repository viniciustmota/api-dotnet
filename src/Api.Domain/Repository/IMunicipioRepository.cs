using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IMunicipioRepository : IRepository<MunicipioEntity, Guid>
    {
        Task<MunicipioEntity> GetCompleteById(Guid id);
        Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE);
        Task<IEnumerable<MunicipioEntity>> GetAll();
        IQueryable<MunicipioEntity> GetQueryable();
    }
}