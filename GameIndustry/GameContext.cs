using GameIndustry.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameIndustry
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Studio> Studios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-MCLUN3BN\SQLSERVER;Database=GamesDb;Trusted_Connection=True;Encrypt=False;");
        }
    }
}
