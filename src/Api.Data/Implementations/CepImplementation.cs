using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CepImplementation : BaseRepository<CepEntity, Guid>, ICepRepository
    {
        private DbSet<CepEntity> _dataset;

        public CepImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<CepEntity>();
        }

        public Task<CepDtoVisualizacao> GetVisualizacao(string cep)
        {
            throw new NotImplementedException();
        }

        public async Task<CepEntity> SelectAsync(string cep)
        {
            return await _dataset.Include(c => c.Municipio)
                                    .ThenInclude(m => m.Uf)
                                    .FirstOrDefaultAsync(u => u.Cep.Equals(cep));
        }
        
    }
}