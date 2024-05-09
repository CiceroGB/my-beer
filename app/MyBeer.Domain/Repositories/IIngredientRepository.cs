using MyBeer.Domain.Entities;


namespace MyBeer.Domain.Repositories
{
    public interface IIngredientRepository
    {
        Task<Ingredient> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Ingredient>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(Ingredient ingredient, CancellationToken cancellationToken);
        Task UpdateAsync(Ingredient ingredient, CancellationToken cancellationToken);
        Task DeleteAsync(Ingredient ingredient, CancellationToken cancellationToken);
    }
}
