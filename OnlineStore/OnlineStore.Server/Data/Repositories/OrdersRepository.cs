using OnlineStore.Server.Model;

namespace OnlineStore.Server.Data.Repositories
{
    public class OrdersRepository : BaseRepository<Order>
    {
        public OrdersRepository(StoreContext context) : base(context)
        {
        }
    }
}
