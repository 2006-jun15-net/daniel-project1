using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project1.Data.Model
{
    public partial class Project01Context : DbContext
    {
        public Project01Context()
        {
        }

        public Project01Context(DbContextOptions<Project01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerEntity> CustomerEntity { get; set; }
        public virtual DbSet<InventoryEntity> InventoryEntity { get; set; }
        public virtual DbSet<LocationEntity> LocationEntity { get; set; }
        public virtual DbSet<OrderHistoryEntity> OrderHistoryEntity { get; set; }
        public virtual DbSet<OrdersEntity> OrdersEntity { get; set; }
        public virtual DbSet<ProductEntity> ProductEntity { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEntity>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<InventoryEntity>(entity =>
            {
                entity.HasKey(e => new { e.LocationId, e.ProductId })
                    .HasName("PK_Inventory");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.InventoryEntity)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Inventory_Location_LocationID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InventoryEntity)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Inventory_Product_ProductID");
            });

            modelBuilder.Entity<LocationEntity>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK_Location");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<OrderHistoryEntity>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_OrderHistory");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderHistoryEntity)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_OrderHistory_Customer_CustomerID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.OrderHistoryEntity)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_OrderHistory_Location_LocationID");
            });

            modelBuilder.Entity<OrdersEntity>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_Order");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersEntity)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Order_OrderHistory_OrderID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrdersEntity)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Order_Product_ProductID");
            });

            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("numeric(10, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
