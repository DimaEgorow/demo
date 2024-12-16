using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp6.Models;

public partial class DemoMaterial5Context : DbContext
{
    public DemoMaterial5Context()
    {
    }

    public DemoMaterial5Context(DbContextOptions<DemoMaterial5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerProduct> PartnerProducts { get; set; }

    public virtual DbSet<ProductImport> ProductImports { get; set; }

    public virtual DbSet<TypeMaterial> TypeMaterials { get; set; }

    public virtual DbSet<TypeProduct> TypeProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6AIEPST\\DIMA;Initial Catalog=demo_material5;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__partners__3213E83F5DF05F77");

            entity.ToTable("partners");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressPartner)
                .HasMaxLength(255)
                .HasColumnName("address_partner");
            entity.Property(e => e.Director)
                .HasMaxLength(255)
                .HasColumnName("director");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Inn).HasColumnName("inn");
            entity.Property(e => e.NamePartner)
                .HasMaxLength(255)
                .HasColumnName("name_partner");
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(20)
                .HasColumnName("number_phone");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.TypePartner)
                .HasMaxLength(10)
                .HasColumnName("type_partner");
        });

        modelBuilder.Entity<PartnerProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__partner___3213E83FB013D8F4");

            entity.ToTable("partner_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountProduct).HasColumnName("count_product");
            entity.Property(e => e.DateSale)
                .HasColumnType("datetime")
                .HasColumnName("date_sale");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.PartnerProductId).HasColumnName("partner_product_id");

            entity.HasOne(d => d.Partner).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__partner_p__partn__412EB0B6");

            entity.HasOne(d => d.PartnerProductNavigation).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.PartnerProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__partner_p__partn__403A8C7D");
        });

        modelBuilder.Entity<ProductImport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83F81D91A41");

            entity.ToTable("product_import");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Articul).HasColumnName("articul");
            entity.Property(e => e.NameProduct)
                .HasMaxLength(255)
                .HasColumnName("name_product");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.TypeProductId).HasColumnName("type_product_id");

            entity.HasOne(d => d.TypeProduct).WithMany(p => p.ProductImports)
                .HasForeignKey(d => d.TypeProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__product_i__type___3D5E1FD2");
        });

        modelBuilder.Entity<TypeMaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__type_mat__3213E83F271F9FE5");

            entity.ToTable("type_material");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PercentMarriage).HasColumnName("percent_marriage");
            entity.Property(e => e.TypeMaterial1)
                .HasMaxLength(255)
                .HasColumnName("type_material");
        });

        modelBuilder.Entity<TypeProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__type_pro__3213E83F12FB90CC");

            entity.ToTable("type_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PercentMarriage).HasColumnName("percent_marriage");
            entity.Property(e => e.TypeProduct1)
                .HasMaxLength(255)
                .HasColumnName("type_product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
