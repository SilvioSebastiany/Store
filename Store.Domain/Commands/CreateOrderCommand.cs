using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Commands
{
    public class CreateOrderCommand : Notifiable<Notification>, ICommand
    {
        public string Customer { get; set; }
        public string ZipCode { get; set; }
        public string PromoCode { get; set; }
        public CreateOrderCommand()
        {
            Items = new List<CreateOrderItemCommand>();
        }

        public CreateOrderCommand(string customer, string zipCode, string promoCode, IList<CreateOrderItemCommand> items)
        {
            Customer = customer;
            ZipCode = zipCode;
            PromoCode = promoCode;
            Items = items;
        }

        public IList<CreateOrderItemCommand> Items { get; set; }

        public event EventHandler? CanExecuteChanged;

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                    .Requires()
                    .IsNotNullOrEmpty(Customer, "Customer", "Cliente inválido")
                    .IsNotNullOrEmpty(ZipCode, "ZipCode", "CEP inválido")
                    .IsGreaterThan(Items.Count, 0, "Items", "Nenhum item do pedido foi encontrado")
            );

            foreach (var item in Items)
            {
                item.Validate();
                AddNotifications(item);
            }
        }

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}