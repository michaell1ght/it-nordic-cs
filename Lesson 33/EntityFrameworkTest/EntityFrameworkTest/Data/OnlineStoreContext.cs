using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest.Data
{
    public class OnlineStoreContext : DbContext
    {
        public OnlineStoreContext()
        {
            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;"
            + "Initial Catalog=OnlineStoreEF;"
            + "Integrated Security=true;";
        }

        private string _connectionString;

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                    .HasAlternateKey(c => c.Name)
                    .HasName("UQ_Customers_Name");

            modelBuilder
                .Entity<OrderItem>()
                    .HasKey("OrderId", "ProductId")
                    .HasName("UQ_OrderItems");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
