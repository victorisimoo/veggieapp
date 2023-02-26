using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace veggie_app.Models;

public partial class VeggiedbContext : DbContext
{
    public VeggiedbContext()
    {
    }

    public VeggiedbContext(DbContextOptions<VeggiedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.IdUser, "idUser");

            entity.Property(e => e.IdOrder).HasColumnName("idOrder");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("date");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(255)
                .HasColumnName("shipping_address");
            entity.Property(e => e.ShippingCity)
                .HasMaxLength(255)
                .HasColumnName("shipping_city");
            entity.Property(e => e.ShippingCountry)
                .HasMaxLength(255)
                .HasColumnName("shipping_country");
            entity.Property(e => e.ShippingState)
                .HasMaxLength(255)
                .HasColumnName("shipping_state");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("orders_ibfk_1");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => e.IdOrderProducts).HasName("PRIMARY");

            entity.ToTable("order_products");

            entity.HasIndex(e => e.IdOrder, "idOrder");

            entity.HasIndex(e => e.IdProduct, "idProduct");

            entity.Property(e => e.IdOrderProducts).HasColumnName("idOrderProducts");
            entity.Property(e => e.IdOrder).HasColumnName("idOrder");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(10, 2)
                .HasColumnName("unit_price");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("order_products_ibfk_1");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("order_products_ibfk_2");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.IdPerson).HasName("PRIMARY");

            entity.ToTable("persons");

            entity.HasIndex(e => e.IdUser, "person_users_id");

            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("firstName");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("lastName");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .HasColumnName("phone");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .HasColumnName("state");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("person_users_id");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.IdUser, "fk_Products_users");

            entity.HasIndex(e => e.IdCategory, "idCategory");

            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("products_ibfk_1");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Products_users");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.IdSession).HasName("PRIMARY");

            entity.ToTable("sessions");

            entity.HasIndex(e => e.IdUser, "sessions_fk_user_id");

            entity.Property(e => e.IdSession).HasColumnName("idSession");
            entity.Property(e => e.ExpiresAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("expires_at");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .HasColumnName("token");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("sessions_fk_user_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.TypeUser)
                .HasDefaultValueSql("'0'")
                .HasColumnName("typeUser");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
