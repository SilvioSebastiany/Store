using Flunt.Notifications;

namespace Store.Domain.Entities
{
    // Serve como base para todas as entidades
    public class Entity : Notifiable<Notification>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}