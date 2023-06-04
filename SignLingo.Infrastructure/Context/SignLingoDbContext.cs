using Microsoft.EntityFrameworkCore;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure.Context;

public class SignLingoDbContext : DbContext
{
    public SignLingoDbContext()
    {
        
    }
    
    public SignLingoDbContext(DbContextOptions<SignLingoDbContext> options) : base(options)
    {
    }

    public DbSet<Country> Country { get; set; }
    public DbSet<City> City { get; set; }
    public DbSet<User> User { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=root;Database=signlingo-db", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Country>().ToTable("country");
        modelBuilder.Entity<Country>().HasKey(country => country.Id);
        modelBuilder.Entity<Country>().Property(country => country.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Country>().Property(country => country.Country_Name).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<Country>().HasMany(country => country.Cities)
            .WithOne()
            .HasForeignKey(city => city.CountryId )
            .IsRequired();
        
        modelBuilder.Entity<City>().ToTable("city");
        modelBuilder.Entity<City>().HasKey(city => city.Id);
        modelBuilder.Entity<City>().Property(city => city.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<City>().Property(city => city.City_Name).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<City>().HasMany(city => city.Users)
            .WithOne()
            .HasForeignKey(user => user.CityId )
            .IsRequired();
        
        modelBuilder.Entity<User>().ToTable("user");
        modelBuilder.Entity<User>().HasKey(user => user.Id);
        modelBuilder.Entity<User>().Property(user => user.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(user => user.First_Name).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<User>().Property(user => user.Last_Name).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<User>().Property(user => user.Email).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<User>().Property(user => user.BirthDate).HasColumnType("date");
        modelBuilder.Entity<User>().Property(user => user.IsActive).HasDefaultValue(true);
    }
}