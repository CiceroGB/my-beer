namespace MyBeer.Domain.Entities
{
    public class Beer
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        private List<Guid> _ingredients;
        public IReadOnlyList<Guid> Ingredients => _ingredients.AsReadOnly();


        public Beer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
            Name = name;
        }


        public void AddIngredient(Guid ingredientId)
        {
            _ingredients.Add(ingredientId);
        }
    }
}
