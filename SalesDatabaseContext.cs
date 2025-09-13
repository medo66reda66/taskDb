using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using SalesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatabase.Data
{
    public class SalesDatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial catalog = EFtaskDb1;Integrated Security=True;Connect Timeout=30;" +
                "Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);
            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .IsUnicode(false)
                .HasMaxLength(80);
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsUnicode(true)
                .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .Property(c => c.Name)
                .IsUnicode(true)
                .HasMaxLength(100);
            modelBuilder.Entity<Product>()
                .Property(c => c.Description)
                .HasMaxLength(250);

            modelBuilder.Entity<Store>()
                .HasKey(s => s.StoreId);
            modelBuilder.Entity<Store>()
                .Property(s => s.Name)
                .IsUnicode(true)
                .HasMaxLength(80);

            modelBuilder.Entity<Sale>()
                .HasKey(s => new { s.SaleId, s.ProductId, s.StoreId, s.CustomerId });
            modelBuilder.Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("GETDATE()");
        }
    }
    
}
