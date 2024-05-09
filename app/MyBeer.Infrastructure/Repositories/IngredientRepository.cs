using Microsoft.EntityFrameworkCore;
using MyBeer.Domain.Entities;
using MyBeer.Domain.Repositories;


namespace MyBeer.Infrastructure.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly ApplicationDbContext _context;

        public IngredientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Ingredient> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var ingredient = await _context.Ingredients.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return ingredient!;

        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Ingredients
                                 .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Ingredient ingredient, CancellationToken cancellationToken = default)
        {
            await _context.Ingredients.AddAsync(ingredient, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Ingredient ingredient, CancellationToken cancellationToken = default)
        {
            _context.Ingredients.Update(ingredient);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Ingredient ingredient, CancellationToken cancellationToken = default)
        {
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
