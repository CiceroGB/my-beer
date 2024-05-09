using MyBeer.Domain.Entities;

namespace MyBeer.Domain.Repositories
{
    public interface IBeerRepository
    {
        Task<Beer> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Beer>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(Beer beer, CancellationToken cancellationToken);
        Task UpdateAsync(Beer beer, CancellationToken cancellationToken);
        Task DeleteAsync(Beer beer, CancellationToken cancellationToken);
    }
}
