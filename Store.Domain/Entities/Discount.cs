namespace Store.Domain.Entities
{
    public class Discount : Entity
    {
        public Discount(decimal amount, decimal percentage, DateTime expireDate)
        {
            Amount = amount;
            ExpireDate = expireDate;
        }

        public decimal Amount { get; private set; }
        public DateTime ExpireDate { get; private set;}

        // Método que verifica se o desconto é válido
        public bool IsValid()
        {
            return DateTime.Compare(DateTime.Now, ExpireDate) < 0;
        }

        // Método que retorna o valor do desconto
        public decimal Value()
        {
            if(IsValid())
                return Amount;
            else
                return 0;
        }
    }
}