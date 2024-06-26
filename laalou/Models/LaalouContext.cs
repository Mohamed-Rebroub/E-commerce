using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace laalou.Models;

public partial class LaalouContext : DbContext
{
   

    public LaalouContext(DbContextOptions<LaalouContext> options):base(options)
    {
            }



    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Produit> Produits { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

/*    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=REBROUB\\MSSQLSERVER01;Database=laalou;TrustServerCertificate=True;Trusted_Connection=True;");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("Cart");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Cart_Produit");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Produit>(entity =>
        {
            entity.ToTable("Produit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Prix).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Cat).WithMany(p => p.Produits)
                .HasForeignKey(d => d.Catid)
                .HasConstraintName("FK_Produit_Category");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Review");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
