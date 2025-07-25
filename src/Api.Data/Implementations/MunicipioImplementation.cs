using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class MunicipioImplementation : BaseRepository<MunicipioEntity, Guid>, IMunicipioRepository
    {
        private DbSet<MunicipioEntity> _dataset;

        public MunicipioImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<MunicipioEntity>();
        }

        public async Task<IEnumerable<MunicipioEntity>> GetAll()
        {
            return await _dataset.Include(m => m.Uf).ToListAsync();
        }

        public async Task<MunicipioEntity> GetCompleteByIBGE(int codIBGE)
        {
            return await _dataset.Include(m => m.Uf)
                                    .FirstOrDefaultAsync(m => m.CodIBGE.Equals(codIBGE));
        }

        public async Task<MunicipioEntity> GetCompleteById(Guid id)
        {
            return await _dataset.Include(m => m.Uf)
                                    .FirstOrDefaultAsync(m => m.Id.Equals(id));
        }

        IQueryable<MunicipioEntity> IMunicipioRepository.GetQueryable()
        {
            return  _dataset.Include(m => m.Uf).AsNoTracking();
        }
    }
}