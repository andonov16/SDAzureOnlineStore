using Microsoft.EntityFrameworkCore;
using OnlineStore.Server.Model;

namespace OnlineStore.Server.Data.Repositories
{
    public class OrderItemsRepository : BaseRepository<OrderItem>
    {
        public OrderItemsRepository(StoreContext context) : base(context)
        {
        }



        public override async Task<OrderItem> ReadAsync(int id)
        {
            return await context.Set<OrderItem>()
               .Include(c => c.Order)
               .Include(c => c.Product)
               .FirstAsync(x => x.Id == id);
        }
        public override async Task<OrderItem> ReadFullAsync(int id)
        {
            return await context.Set<OrderItem>()
               .Include(c => c.Order)
               .Include(c => c.Product)
               .FirstAsync(x => x.Id == id);
        }

        public override async Task<ICollection<OrderItem>> ReadAllAsync()
        {
            var set = context.Set<OrderItem>()
               .Include(c => c.Order)
               .Include(c => c.Product)
                .AsQueryable();
            return await set.ToListAsync();
        }
    }
}
