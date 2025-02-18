using System.Linq.Expressions;
using Store.Domain.Entities;

namespace Store.Domain.Queries
{
    public static class ProductQueries
    {
        // Expression<Func<Product, bool>>: é uma expressão lambda que recebe um Product e retorna um bool
        public static Expression<Func<Product, bool>> GetActiveProducts()
        {
            return x => x.Active;
        }

        public static Expression<Func<Product, bool>> GetInactiveProducts()
        {
            return x => !x.Active;
        }
    }
}