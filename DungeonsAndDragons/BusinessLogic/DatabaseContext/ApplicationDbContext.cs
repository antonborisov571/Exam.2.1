using Microsoft.EntityFrameworkCore;
using Models;

namespace BusinessLogic.DatabaseContext;

public class ApplicationDbContext : DbContext
{
    public DbSet<Monster> Monsters { get; set; }   
    public ApplicationDbContext(DbContextOptions options) : base(options) 
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        var monsters = new Monster[] 
        {
            new Monster()
            {
                Id = 1,
                Name = "Гоблин",
                HitPoints = 7,
                AttackModifier = 0,
                AttackPerRound = 1,
                Damage = "2d6",
                DamageModifier = -1,
                ArmorClass = 15,
            },
            new Monster()
            {
                Id = 2,
                Name = "Зомби",
                HitPoints = 22,
                AttackModifier = 9,
                AttackPerRound = 1,
                Damage = "3d8",
                DamageModifier = 1,
                ArmorClass = 8,
            },
            new Monster()
            {
                Id = 3,
                Name = "Гиена",
                HitPoints = 5,
                AttackModifier = 1,
                AttackPerRound = 1,
                Damage = "1d8",
                DamageModifier = 0,
                ArmorClass = 11,
            }
        };
        modelBuilder.Entity<Monster>().HasData(monsters);
    }
}
