using Store.Domain.Commands;

namespace Store.Domain.Utils
{
    public static class ExtractGuids
    {
        public static IEnumerable<Guid> Extract(IEnumerable<CreateOrderItemCommand> items)
        {
            
            var guids = new List<Guid>();

            foreach (var item in items)
                guids.Add(item.ProductId);

            return guids;
        }
    }
}