using MyBeer.Domain.Entities;
using MyBeer.Domain.Repositories;
using MyBeer.Application.Interfaces;

namespace MyBeer.Application.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _beerRepository;

        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public async Task<IEnumerable<Beer>> GetAllBeersAsync(CancellationToken cancellationToken = default)
        {
            return await _beerRepository.GetAllAsync(cancellationToken);
        }

        public async Task<Beer> GetBeerByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _beerRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task AddBeerAsync(Beer beer, CancellationToken cancellationToken = default)
        {
            await _beerRepository.AddAsync(beer, cancellationToken);
            // Adicional: aqui você pode adicionar lógica de negócios antes de adicionar ao repositório
        }

        public async Task UpdateBeerAsync(Beer beer, CancellationToken cancellationToken = default)
        {
            await _beerRepository.UpdateAsync(beer, cancellationToken);
            // Adicional: aqui você pode adicionar lógica de validação ou negócios antes da atualização
        }

        public async Task DeleteBeerAsync(Beer beer, CancellationToken cancellationToken = default)
        {
            await _beerRepository.DeleteAsync(beer, cancellationToken);
            // Adicional: tratativas antes de deletar, como verificações de dependência
        }
    }
}
