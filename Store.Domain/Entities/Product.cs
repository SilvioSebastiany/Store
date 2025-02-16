namespace Store.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string name, decimal price, bool active)
        {
            Name = name;
            Price = price;
            Active = active;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
    }
}