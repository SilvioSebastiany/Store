namespace Store.Domain.Enums
{
    public enum EOrderStatus
    {
        WaitingPayment = 1, // Aguardando pagamento
        WaitingDelivery = 2, // Aguardando entrega
        Canceled = 3   // Cancelado
    }
}