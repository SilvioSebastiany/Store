using Store.Domain.Entities;
using Store.Domain.Repositories.interfaces;
using System;

namespace Store.Tests.Repositories
{
    public class FakeDiscountRepository : IDiscountRepository
    {
        public Discount Get(string code)
        {
            if (code == "12345678")
                return new Discount(10, 0, DateTime.Now.AddDays(5));
           

            if (code == "11111111")
                return new Discount(10, 10, DateTime.Now.AddDays(-5));

            return null;

        }
    }
}
