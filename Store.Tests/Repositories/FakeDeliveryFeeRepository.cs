using Store.Domain.Repositories.interfaces;

namespace Store.Tests.Repositories
{
    public class FakeDeliveryFeeRepository : IDeliveryFeeRepository
    {
        public decimal Get(string zipCode)
        {
            return 10;
        }
    }
}
