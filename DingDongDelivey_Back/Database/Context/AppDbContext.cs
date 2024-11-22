using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingDongDelivey_Back.Models;
using Microsoft.EntityFrameworkCore;
using DingDongDelivey_Back.Database.Context;

namespace DingDongDelivey_Back.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
            //base.OnModelCreating(builder);
            //builder.Entity<User>().HasKey(i => i.Username);
            builder.Entity<User>().HasKey(u => u.userId);
            builder.Entity<Product>().HasKey(p => p.id);
            builder.Entity<Order>().HasKey(p => p.orderId);

            builder.Entity<User>().Property(u => u.userId).ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(u => u.id).ValueGeneratedOnAdd();
            builder.Entity<Order>().Property(u => u.orderId).ValueGeneratedOnAdd();


            //RELACIJE TABELA
            builder.Entity<User>().HasMany(x => x.orders)
                                  .WithOne(x => x.buyer)
                                  .HasForeignKey(x => x.buyerId)
                                  .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductOrder>().HasKey(x => new { x.ProductId, x.OrderId });

            builder.Entity<ProductOrder>().HasOne<Product>(x => x.Product)
                                            .WithMany(x => x.orders)
                                            .HasForeignKey(x => x.ProductId);

            builder.Entity<ProductOrder>().HasOne<Order>(x => x.Order)
                                            .WithMany(x => x.orderItems)
                                            .HasForeignKey(x => x.OrderId);

            //builder.Entity<Order>().HasMany(x => x.orderItems)
            //                       .WithMany(x => x.orders);


            //podesiti Order to Product relaciju, many to many, mozda string[] za kljuc
            //srediti socialLogging
            //email verifikacija
        }
    }
}
