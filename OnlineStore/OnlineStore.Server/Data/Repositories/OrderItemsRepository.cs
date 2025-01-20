using OnlineStore.Server.Model;

namespace OnlineStore.Server.Data.Repositories
{
    public class OrderItemsRepository : BaseRepository<OrderItem>
    {
        public OrderItemsRepository(StoreContext context) : base(context)
        {
        }
    }
}
