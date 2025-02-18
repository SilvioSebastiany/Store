using Store.Domain.Entities;
using Store.Domain.Repositories.interfaces;

namespace Store.Tests.Repositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer Get(string document)
        {
            if (document == "12345678911")
            {
               return new Customer("Silvio Sebastiany", "silvio.sebastiany@gmail.com");
            } 

            return null;
        }
    }
}