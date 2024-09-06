using DocumentManagementEx.Entity;
using Microsoft.EntityFrameworkCore;

namespace DocumentManagementEx;

public class DocumentDbContext : DbContext
{
    public DocumentDbContext(DbContextOptions<DocumentDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=DocumentManagementDb;Trusted_Connection=True;");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Document> Documents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>().ToTable("Documents");
        modelBuilder.Entity<Document>().HasKey(d => d.Id);
        modelBuilder.Entity<Document>().Property(d => d.FileName).IsRequired();
        modelBuilder.Entity<Document>().Property(d => d.Data).IsRequired();
        modelBuilder.Entity<Document>().Property(d => d.UploadDate).IsRequired();

        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().Property(u => u.Name).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.Role).IsRequired();

        modelBuilder.Entity<User>()
            .HasMany(u => u.Documents)
            .WithOne()
            .HasForeignKey(d => d.UserId);
    
    }
}