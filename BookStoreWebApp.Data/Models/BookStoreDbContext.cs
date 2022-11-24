using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApp.Data.Models;

public partial class BookStoreDbContext : DbContext
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApiRequest> ApiRequests { get; set; }

    public virtual DbSet<ApiToken> ApiTokens { get; set; }

    public virtual DbSet<ApiUser> ApiUsers { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookSubscription> BookSubscriptions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserSubscription> UserSubscriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-A5OUCJP\\MSSQLSERVER2019;Database=BookStoreDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiRequest>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ApiPath)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ControllerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ApiToken>(entity =>
        {
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.TokenValue).IsUnicode(false);
        });

        modelBuilder.Entity<ApiUser>(entity =>
        {
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Author)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PurchasePrice).HasColumnType("smallmoney");
        });

        modelBuilder.Entity<BookSubscription>(entity =>
        {
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.TokenValue).IsUnicode(false);
        });

        modelBuilder.Entity<UserSubscription>(entity =>
        {
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
