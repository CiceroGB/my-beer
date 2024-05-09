using Microsoft.EntityFrameworkCore;
using MyBeer.Domain.Entities;
using MyBeer.Domain.Repositories;


namespace MyBeer.Infrastructure.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private readonly ApplicationDbContext _context;

        public BeerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Beer> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var beer = await _context.Beers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return beer!;
        }

        public async Task<IEnumerable<Beer>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Beers
                                 .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Beer beer, CancellationToken cancellationToken)
        {
            await _context.Beers.AddAsync(beer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Beer beer, CancellationToken cancellationToken)
        {
            _context.Beers.Update(beer);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Beer beer, CancellationToken cancellationToken)
        {
            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
