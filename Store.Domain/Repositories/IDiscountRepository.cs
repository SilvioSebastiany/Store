using Store.Domain.Entities;

namespace Store.Domain.Repositories.interfaces
{
    public interface IDiscountRepository
    {
        Discount Get(Guid id);
    }
}
