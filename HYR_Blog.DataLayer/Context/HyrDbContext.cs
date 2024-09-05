using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HYR_Blog.DataLayer.Entitys;
using HYR_Blog.DataLayer.MapFluentApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace HYR_Blog.DataLayer.Context
{
    public class HyrDbContext : DbContext
    {
        public HyrDbContext(DbContextOptions<HyrDbContext> option) : base(option)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> Images { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Transportation> Transportations { get; set; }
        public DbSet<Pay> Pays { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasQueryFilter(p => p.IsDelete == false);
            modelBuilder.Entity<CartItem>().HasQueryFilter(p => p.IsDelete == false);
            modelBuilder.Entity<Product>().HasQueryFilter(p => p.IsDelete == false);
            modelBuilder.Entity<Comment>().HasQueryFilter(p => p.IsDelete == false);
            modelBuilder.Entity<User>().HasQueryFilter(p => p.IsDelete == false);
            modelBuilder.Entity<ProductProperty>().HasQueryFilter(p => p.IsDelete == false);


            modelBuilder.Entity<Product>().Property(p => p.Inventory).HasDefaultValue(10);
            modelBuilder.Entity<Product>().Property(p => p.Weight).HasDefaultValue(500);
            modelBuilder.Entity<Product>().Property(p => p.Score).HasDefaultValue(5);
            modelBuilder.Entity<Product>().Property(p => p.CreationDate).HasDefaultValue(DateTime.Now);


            //insert Data in Order Status
            modelBuilder.Entity<OrderStatus>().HasData(new List<OrderStatus>()
            {
                new OrderStatus() { StatusTitle = OrderStatusTitle.Accepted , StatusId = 1 , Priority = 3},
                new OrderStatus() { StatusTitle = OrderStatusTitle.Canceled ,StatusId = 2 , Priority = 2},
                new OrderStatus() { StatusTitle = OrderStatusTitle.Finalized , StatusId = 3 , Priority = 5},
                new OrderStatus() { StatusTitle = OrderStatusTitle.Posted ,StatusId = 4 , Priority  = 4},
                new OrderStatus() { StatusTitle = OrderStatusTitle.NewOrder ,StatusId = 5 , Priority = 1}
            });

            //insert Data in User Role
            modelBuilder.Entity<UserRole>().HasData(new List<UserRole>()
            {
                new UserRole(){UserRoleId = 1,UserRoleTitle = "Admin"},
                new UserRole(){UserRoleId = 2,UserRoleTitle = "Person"},
                new UserRole(){UserRoleId = 3 , UserRoleTitle = "User"}
            });




            modelBuilder.Entity<Order>().HasIndex(o => o.SendCode).IsUnique();
            modelBuilder.Entity<User>().HasIndex(p => p.UserName).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(p => p.ProductName).IsUnique();


            //Set Transportation Configuration In There  
            modelBuilder.ApplyConfiguration<Transportation>(new TransportationMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
    }
}
