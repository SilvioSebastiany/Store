using Store.Domain.Entities;
using Store.Domain.Queries;

namespace Store.Tests.Queries
{
    [TestClass]
    public class ProductQueriesTests
    {
        private List<Product> _products;

        public ProductQueriesTests()
        {
            _products = new List<Product>();
            
            _products.Add (new Product("Product 1", 85, true));
            _products.Add (new Product("Product 2", 5, false));
            _products.Add (new Product("Product 3", 3, true));
            _products.Add (new Product("Product 4", 10, false));
            _products.Add (new Product("Product 5", 4, true));
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_ativos_deve_retornar_3()
        {
            var result = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());
            Assert.AreEqual(3, result.Count());
        
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_inativos_deve_retornar_2()
        {
            var result = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());
                Assert.AreEqual(2, result.Count());
        }
    }
}