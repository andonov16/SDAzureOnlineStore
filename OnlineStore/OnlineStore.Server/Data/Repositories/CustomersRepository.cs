using OnlineStore.Server.Model;

namespace OnlineStore.Server.Data.Repositories
{
    public class CustomersRepository : BaseRepository<Customer>
    {
        public CustomersRepository(StoreContext context) : base(context)
        {
        }
    }
}
