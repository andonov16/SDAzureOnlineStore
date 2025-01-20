using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Server.Data;
using OnlineStore.Server.Data.Repositories;

namespace OnlineStore.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
            builder.Services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<CartItemsRepository>();
            builder.Services.AddScoped<CartsRepository>();
            builder.Services.AddScoped<CustomersRepository>();
            builder.Services.AddScoped<OrderItemsRepository>();
            builder.Services.AddScoped<OrdersRepository>();
            builder.Services.AddScoped<ProductsRepository>();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
