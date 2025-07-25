using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IRepository<T, TId> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(TId id);
        Task<T> SelectAsync(TId id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(TId id);
        Task<IQueryable<T>> GetQueryable();
    }
}
