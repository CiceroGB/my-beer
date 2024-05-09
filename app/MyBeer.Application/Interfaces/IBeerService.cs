using MyBeer.Domain.Entities;


namespace MyBeer.Application.Interfaces
{
    public interface IBeerService
    {
        Task<IEnumerable<Beer>> GetAllBeersAsync(CancellationToken cancellationToken);
        Task<Beer> GetBeerByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddBeerAsync(Beer beer, CancellationToken cancellationToken);
        Task UpdateBeerAsync(Beer beer, CancellationToken cancellationToken);
        Task DeleteBeerAsync(Beer beer, CancellationToken cancellationToken);
    }
}
