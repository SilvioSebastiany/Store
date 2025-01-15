using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(product, "Product", "Produto inválido")
                .IsGreaterThan(quantity, 0, "Quantity", "A quantidade deve ser maior que zero")
            );
            
            Product = product;
            Price = product != null ? product.Price : 0;
            Quantity = quantity;
        }

        public Product Product { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        // Método que retorna o valor total do item
        public decimal Total()
        {
            return Product.Price * Quantity;
        }
    }
}