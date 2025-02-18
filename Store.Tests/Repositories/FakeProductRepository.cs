using Store.Domain.Entities;
using Store.Domain.Repositories.interfaces;
using System;
using System.Collections.Generic;

namespace Store.Tests.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Get(IEnumerable<Guid> ids)
        {
            var products = new List<Product>();
            foreach (var id in ids)
            {
                products.Add(new Product("Product " + id.ToString(), 10, true));
            }
            return products;
        }
    }
}