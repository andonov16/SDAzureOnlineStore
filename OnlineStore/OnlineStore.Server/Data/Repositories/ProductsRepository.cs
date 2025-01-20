using OnlineStore.Server.Model;

namespace OnlineStore.Server.Data.Repositories
{
    public class ProductsRepository : BaseRepository<Product>
    {
        public ProductsRepository(StoreContext context) : base(context)
        {
        }
    }
}
