using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Web_API_Proyecto_final.models;

namespace Web_API_Proyecto_final.Database;

public partial class DatabaseContext : DbContext    
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options)
    {
    }
    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<ProductSold> ProductSold { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.UsersId, "IX_Products_UsersId");

            entity.Property(e => e.Name).HasDefaultValue("");
            entity.Property(e => e.Stock).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalProduct).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Products).HasForeignKey(d => d.UsersId);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasIndex(e => e.SalesId, "IX_Sales_SalesId");

            entity.HasIndex(e => e.UsersId, "IX_Sales_UsersId");

            entity.HasOne(d => d.Sales).WithMany(p => p.InverseSales).HasForeignKey(d => d.SalesId);

            entity.HasOne(d => d.Users).WithMany(p => p.Sales).HasForeignKey(d => d.UsersId);
        });
        modelBuilder.Entity<ProductSold>(entity =>
        {
            entity.HasIndex(e => e.ProductId, "IX_ProductSold_ProductId");
            entity.HasIndex(e => e.SaleId, "IX_ProductSold_SaleId");
            entity.Property(e => e.Stock).HasColumnType("int");

            entity.HasOne(d => d.IdProductNavigation)
                .WithMany(p => p.ProductSold)
                .HasForeignKey(d => d.ProductId);

            entity.HasOne(d => d.IdSaleNavigation)
                .WithMany(p => p.ProductSold)
                .HasForeignKey(d => d.SaleId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
