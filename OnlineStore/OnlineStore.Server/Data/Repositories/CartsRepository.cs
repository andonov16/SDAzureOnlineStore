using Microsoft.EntityFrameworkCore;
using OnlineStore.Server.Model;

namespace OnlineStore.Server.Data.Repositories
{
    public class CartsRepository:BaseRepository<Cart>
    {
        public CartsRepository(StoreContext context) : base(context)
        {
        }



        public override async Task<Cart> ReadAsync(int id)
        {
            return await context.Set<Cart>()
               .Include(c => c.CartItems)
               .Include(c => c.Customer)
               .FirstAsync(x => x.Id == id);
        }
        public override async Task<Cart> ReadFullAsync(int id)
        {
            return await context.Set<Cart>()
               .Include(c => c.CartItems)
               .Include(c => c.Customer)
               .FirstAsync(x => x.Id == id);
        }

        public override async Task<ICollection<Cart>> ReadAllAsync()
        {
            var set = context.Set<Cart>()
                .Include(c => c.CartItems)
                .Include(c => c.Customer)
                .AsQueryable();
            return await set.ToListAsync();
        }
    }
}
