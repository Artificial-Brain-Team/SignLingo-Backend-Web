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
    public DbSet<UserModule> UserModule { get; set; }
    public DbSet<Module> Module { get; set; }
    public DbSet<Exercise> Exercise { get; set; }
    public DbSet<Answer> Answers { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=sql10.freemysqlhosting.net,3306;Uid=sql10628037;Pwd=uBzjKgcgnP;Database=sql10628037", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Module>().ToTable("module");
        modelBuilder.Entity<Module>().HasKey(module => module.Id);
        modelBuilder.Entity<Module>().Property(module => module.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Module>().Property(module => module.Module_Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Module>().Property(module => module.Image).IsRequired();
        modelBuilder.Entity<Module>().HasMany(module => module.Exercises)
            .WithOne()
            .HasForeignKey(exercise => exercise.ModuleId)
            .IsRequired();
        modelBuilder.Entity<Module>().Property(module => module.DateCreated);
        modelBuilder.Entity<Module>().Property(module => module.DateUpdated);
        modelBuilder.Entity<Module>().Property(module => module.IsActive).HasDefaultValue(true);

        modelBuilder.Entity<Exercise>().ToTable("exercise");
        modelBuilder.Entity<Exercise>().HasKey(exercise => exercise.Id);
        modelBuilder.Entity<Exercise>().Property(exercise => exercise.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Exercise>().Property(exercise => exercise.Question).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Exercise>().Property(exercise => exercise.Image);
        modelBuilder.Entity<Exercise>().HasMany(exercise => exercise.Answers)
            .WithOne().HasForeignKey(answer => answer.ExerciseId).IsRequired();
        modelBuilder.Entity<Exercise>().Property(exercise => exercise.DateCreated);
        modelBuilder.Entity<Exercise>().Property(exercise => exercise.DateUpdated);
        modelBuilder.Entity<Exercise>().Property(exercise => exercise.IsActive).HasDefaultValue(true);

        modelBuilder.Entity<Answer>().ToTable("answer");
        modelBuilder.Entity<Answer>().HasKey(answer => answer.Id);
        modelBuilder.Entity<Answer>().Property(answer => answer.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Answer>().Property(answer => answer.Answer_text).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<Answer>().Property(answer => answer.IsCorrect).IsRequired();
        modelBuilder.Entity<Answer>().Property(answer => answer.DateCreated);
        modelBuilder.Entity<Answer>().Property(answer => answer.DateUpdated);
        modelBuilder.Entity<Answer>().Property(answer => answer.IsActive).HasDefaultValue(true);

        modelBuilder.Entity<Country>().ToTable("country");
        modelBuilder.Entity<Country>().HasKey(country => country.Id);
        modelBuilder.Entity<Country>().Property(country => country.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Country>().Property(country => country.Country_Name).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<Country>().HasMany(country => country.Cities)
            .WithOne()
            .HasForeignKey(city => city.CountryId )
            .IsRequired();
        modelBuilder.Entity<Country>().Property(country => country.DateCreated);
        modelBuilder.Entity<Country>().Property(country => country.DateUpdated);
        modelBuilder.Entity<Country>().Property(country => country.IsActive).HasDefaultValue(true);
        
        modelBuilder.Entity<City>().ToTable("city");
        modelBuilder.Entity<City>().HasKey(city => city.Id);
        modelBuilder.Entity<City>().Property(city => city.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<City>().Property(city => city.City_Name).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<City>().HasMany(city => city.Users)
            .WithOne()
            .HasForeignKey(user => user.CityId )
            .IsRequired();
        modelBuilder.Entity<City>().Property(city => city.DateCreated);
        modelBuilder.Entity<City>().Property(city => city.DateUpdated);
        modelBuilder.Entity<City>().Property(city => city.IsActive).HasDefaultValue(true);
        
        modelBuilder.Entity<User>().ToTable("user");
        modelBuilder.Entity<User>().HasKey(user => user.Id);
        modelBuilder.Entity<User>().Property(user => user.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(user => user.First_Name).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<User>().Property(user => user.Last_Name).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<User>().Property(user => user.Password).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<User>().Property(user => user.Email).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<User>().Property(user => user.BirthDate).HasColumnType("date");
        modelBuilder.Entity<User>().Property(user => user.DateCreated);
        modelBuilder.Entity<User>().Property(user => user.DateUpdated);
        modelBuilder.Entity<User>().Property(user => user.Type).HasDefaultValue("Free");
        modelBuilder.Entity<User>().Property(user => user.IsActive).HasDefaultValue(true);

        modelBuilder.Entity<UserModule>().ToTable("user_module");
        modelBuilder.Entity<UserModule>().HasKey(userModule => new { userModule.UserId, userModule.ModuleId });
        modelBuilder.Entity<UserModule>().Property(userModule => userModule.Grade).HasDefaultValue(0);
    }
}