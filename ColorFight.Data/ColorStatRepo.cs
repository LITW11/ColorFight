using Microsoft.EntityFrameworkCore;

namespace ColorFight.Data;

public class ColorStatRepo
{
    private readonly string _connectionString;

    public ColorStatRepo(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void IncrementColorStat(string name)
    {
        using var ctx = new ColorFightDataContext(_connectionString);
        ctx.Database.ExecuteSqlInterpolated($"UPDATE ColorStats SET Count = Count + 1 WHERE Name = {name}");
    }

    public List<ColorStat> GetStats()
    {
        using var ctx = new ColorFightDataContext(_connectionString);
        return ctx.ColorStats.ToList();
    }
}
