using Store.Domain.Entities;

namespace Store.Domain.Repositories.interfaces
{
   public interface ICustomerRepository
   {
      Customer Get(string document);
   }
}