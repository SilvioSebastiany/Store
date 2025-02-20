using System.Windows.Input;
using Flunt.Notifications;
using Flunt.Validations;


namespace Store.Domain.Commands
{
    public class CreateOrderItemCommand : Notifiable<Notification>, ICommand
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public CreateOrderItemCommand()
        {
            
        }

        public CreateOrderItemCommand(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public event EventHandler? CanExecuteChanged;

        public void Validate()
        {
            AddNotifications( new Contract<Notification>()
                    .Requires()
                    .IsNotNull(ProductId, "ProductId", "Produto inválido")
                    .IsGreaterThan(Quantity, 0, "Quantity", "A quantidade deve ser maior que zero")
            );
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