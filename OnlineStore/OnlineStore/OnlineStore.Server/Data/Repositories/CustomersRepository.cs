using Microsoft.EntityFrameworkCore;
using OnlineStore.Server.Model;

namespace OnlineStore.Server.Data.Repositories
{
    public class CustomersRepository : BaseRepository<Customer>
    {
        public CustomersRepository(StoreContext context) : base(context)
        {
        }


        public override async Task<Customer> ReadAsync(int id)
        {
            return await context.Set<Customer>()
               .Include(c => c.Cart)
               .Include(c => c.Orders)
               .FirstAsync(x => x.Id == id);
        }
        public override async Task<Customer> ReadFullAsync(int id)
        {
            return await context.Set<Customer>()
               .Include(c => c.Cart)
               .Include(c => c.Orders)
               .FirstAsync(x => x.Id == id);
        }

        public override async Task<ICollection<Customer>> ReadAllAsync()
        {
            var set = context.Set<Customer>()
               .Include(c => c.Cart)
               .Include(c => c.Orders)
                .AsQueryable();
            return await set.ToListAsync();
        }
    }
}
