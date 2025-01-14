namespace Store.Domain.Entities
{
    // Serve como base para todas as entidades
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}