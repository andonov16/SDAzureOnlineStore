using OnlineStore.Server.Model;

namespace OnlineStore.Server.Data.Repositories
{
    public class CartsRepository:BaseRepository<Cart>
    {
        public CartsRepository(StoreContext context) : base(context)
        {
        }
    }
}
