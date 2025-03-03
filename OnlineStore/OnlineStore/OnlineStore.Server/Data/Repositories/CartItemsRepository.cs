using OnlineStore.Server.Model;

namespace OnlineStore.Server.Data.Repositories
{
    public class CartItemsRepository : BaseRepository<CartItem>
    {
        public CartItemsRepository(StoreContext context) : base(context)
        {
        }
    }
}
