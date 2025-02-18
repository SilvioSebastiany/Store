namespace Store.Domain.Repositories.interfaces
{
    public interface IDeliveryFeeRepository
    {
        decimal Get(string zipCode);
    }
}
