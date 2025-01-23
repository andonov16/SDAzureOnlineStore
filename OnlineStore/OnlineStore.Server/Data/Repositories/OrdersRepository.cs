using Microsoft.EntityFrameworkCore;
using OnlineStore.Server.Model;

namespace OnlineStore.Server.Data.Repositories
{
    public class OrdersRepository : BaseRepository<Order>
    {
        public OrdersRepository(StoreContext context) : base(context)
        {
        }


        public override async Task<Order> ReadAsync(int id)
        {
            return await context.Set<Order>()
               .Include(c => c.Customer)
               .Include(c => c.OrderItems)
               .FirstAsync(x => x.Id == id);
        }
        public override async Task<Order> ReadFullAsync(int id)
        {
            return await context.Set<Order>()
               .Include(c => c.Customer)
               .Include(c => c.OrderItems)
               .FirstAsync(x => x.Id == id);
        }

        public override async Task<ICollection<Order>> ReadAllAsync()
        {
            var set = context.Set<Order>()
                .Include(c => c.Customer)
                .Include(c => c.OrderItems)
                .AsQueryable();
            return await set.ToListAsync();
        }
    }
}
