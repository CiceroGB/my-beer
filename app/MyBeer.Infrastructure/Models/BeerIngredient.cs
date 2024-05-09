using MyBeer.Domain.Entities;

namespace MyBeer.Infrastructure.Models
{
    public class BeerIngredient
    {
        public BeerIngredient(Guid beerId, Guid ingredientId)
        {
            BeerId = beerId;
            IngredientId = ingredientId;
        }

        public Guid BeerId { get; set; }
        public Guid IngredientId { get; set; }
        public Beer? Beer { get; set; }
        public Ingredient? Ingredient { get; set; }
    }
}
