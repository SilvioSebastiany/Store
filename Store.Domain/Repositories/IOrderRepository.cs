using Store.Domain.Entities;

namespace Store.Domain.Repositories.interfaces
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
