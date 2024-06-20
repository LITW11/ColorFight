using Microsoft.EntityFrameworkCore;

namespace ColorFight.Data;

public class ColorFightDataContext : DbContext
{
    private readonly string _connectionString;

    public ColorFightDataContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.Entity<ColorStat>().HasData(
               new ColorStat { Id = 1, Name = "Primary", Count = 1 },
               new ColorStat { Id = 2, Name = "Secondary", Count = 1 },
               new ColorStat { Id = 3, Name = "Success", Count = 1 },
               new ColorStat { Id = 4, Name = "Danger", Count = 1 },
               new ColorStat { Id = 5, Name = "Warning", Count = 1 },
               new ColorStat { Id = 6, Name = "Info", Count = 1 },
               new ColorStat { Id = 7, Name = "Light", Count = 1 },
               new ColorStat { Id = 8, Name = "Dark", Count = 1 }
           );
    }

    public DbSet<ColorStat> ColorStats { get; set; }
}