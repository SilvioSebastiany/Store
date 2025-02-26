using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repositories.interfaces;
using Store.Domain.Utils;


namespace Store.Domain.Handlers
{
    public class OrderHandler : Notifiable<Notification>,  IHandler<CreateOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository; 
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(
            ICustomerRepository customerRepository, 
            IDeliveryFeeRepository deliveryFeeRepository, 
            IDiscountRepository discountRepository, 
            IProductRepository productRepository, 
            IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _deliveryFeeRepository = deliveryFeeRepository;
            _discountRepository = discountRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            command.Validate();
            if (command.IsValid)
            {
                AddNotifications(command);
                return new GenericCommandResult(false, "Pedido inválido", command.Notifications);
            }

           


            // 1. Recuperar o cliente
            var customer = _customerRepository.Get(command.Customer);

            // 2. Calcular a taxa de entrega
            var deliveryFee = _deliveryFeeRepository.Get(command.ZipCode);

            // 3. Obter o cupom de desconto
            var discount = _discountRepository.Get(command.PromoCode);

            // 4. Gerar o pedido
            var products = _productRepository.Get(ExtractGuids.Extract(command.Items).ToList());
            var order = new Order(customer, deliveryFee, discount); 

            foreach (var item in command.Items)
            {
                var product = products.Where(x => x.Id == item.ProductId).FirstOrDefault();
                order.AddItem(product, item.Quantity);
            }

            // 5. Agrupar as notificações
            AddNotifications(order.Notifications);

            // 6. Verifica se deu tudo certo
            if (!IsValid)
                return new GenericCommandResult(false, "Falha ao gerar o pedido", Notifications);

            // 7. Retornar o resultado
            _orderRepository.Save(order);
            return new GenericCommandResult(true, $"Pedido {order.Number} realizado com sucesso", null);
        }
    }
}