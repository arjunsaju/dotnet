using EcomProductAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using EcomProductAPI.TestModels;
using Microsoft.EntityFrameworkCore;

namespace EcomProductAPI.Models
{
    public class ProductDbContext : IdentityDbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> context) : base(context)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrdersItem { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<UserInfo> userInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Order>(entity =>
            //{
            //    entity.HasOne(d => d.OrderItems)

            //                        .HasForeignKey(d => d.product_id)
            //                        .HasConstraintName("FK_tbl_Order_tbl_productlist");
            //});

            modelBuilder.Entity<OrderItem>(entity =>
            {


                    entity.HasOne(d => d.order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.order_id)
                    .HasConstraintName("FK_tbl_order_items_tbl_Order");

                    entity.HasOne(d => d.product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.product_id)
                    .HasConstraintName("FK_tbl_order_items_tbl_productlist");
            });
            modelBuilder.Entity<Cart>(entity =>
            {


                entity.HasOne(d => d.product)
                 .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.product_id)
                    .HasConstraintName("FK_tbl_cart_tbl_productlist");



                //  OnModelCreatingPartial(modelBuilder);
            });
        }




        }
}
