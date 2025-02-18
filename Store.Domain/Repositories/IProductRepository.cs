using Store.Domain.Entities;

namespace Store.Domain.Repositories.interfaces
{
    public interface IProductRepository
    {
       IEnumerable<Product> Get(IEnumerable<Guid> ids);
    }
}
