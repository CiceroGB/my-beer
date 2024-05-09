
namespace MyBeer.Domain.Entities
{
    public class Ingredient
    {
        public Guid Id { get; private set; } = Guid.NewGuid(); 
        public string Name { get; private set; } 
        public string Description { get; private set; } 

        public Ingredient(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace..", nameof(name));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be null or whitespace.", nameof(description));

            Name = name;
            Description = description;
        }

        public void UpdateDescription(string newDescription)
        {
            if (string.IsNullOrWhiteSpace(newDescription))
                throw new ArgumentException("Description", nameof(newDescription));
            Description = newDescription;
        }
    }
}
