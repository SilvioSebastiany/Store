using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Enums;

namespace Store.Domain.Entities
{
    public class Order : Entity
    {
        public Order(Customer customer, decimal deliveryFee, Discount discount)
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(customer, "Customer", "Cliente inválido")
                .IsGreaterThan(deliveryFee, 0, "DeliveryFee", "Taxa de entrega inválida")
            );

            Customer = customer;
            Date = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8);
            Items = new List<OrderItem>();
            DeliveryFee = deliveryFee;
            Discount = discount;
            Status = EOrderStatus.WaitingPayment;
        }

        public Customer Customer { get; private set; }   
        public DateTime Date { get; private set; }
        public string Number { get; private set; }
        public IList<OrderItem> Items { get; private set; }
        public decimal DeliveryFee { get; private set; }
        public Discount Discount { get; private set; }
        public EOrderStatus Status { get; private set; }

        public void AddItem(Product product, int quantity)
        {
            var item = new OrderItem(product, quantity);
            if(item.IsValid)
                Items.Add(item);
        }

        public decimal Total()
        {
            var total = 0m;
            foreach (var item in Items)
            {
                total += item.Total();
            }

            total += DeliveryFee;
            total -= Discount != null ? Discount.Value() : 0;
            return total;
        }

        public void Pay(decimal amount)
        {
            if(amount == Total())
                Status = EOrderStatus.WaitingDelivery;
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
        }
    }
}