using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OrderManagement.Domain.Entities;

#nullable disable

namespace OrderManagement.Infrastructure.Data
{
    public partial class OrderDbContext : DbContext
    {
        public OrderDbContext()
        {
        }

        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
      
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderNumber).HasMaxLength(20);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_Orders_Vendors");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

        
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
