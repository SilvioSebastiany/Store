using Store.Domain.Entities;
using Store.Domain.Repositories.interfaces;

namespace Store.Tests.Repositories
{
    public class FakeOrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
            // Fake save implementation
        }
    }
}
