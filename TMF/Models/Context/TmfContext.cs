using System.Data.Entity;
using TMF.Models.Entity;

namespace TMF.Models.Context
{
    public class TmfContext : DbContext
    {
        public TmfContext() : base("TmfContext")
        {

        }
        public DbSet<compAtts> compAtt { get; set; }
        public DbSet<filters> filter { get; set; }
        public DbSet<gameComponents> gameComponent { get; set; }
        public DbSet<games> game { get; set; }
        public DbSet<genres> genre { get; set; }
        public DbSet<platforms> platform { get; set; }
        public DbSet<roles> role { get; set; }
        public DbSet<userGameDescs> userGameDesc { get; set; }
        public DbSet<userGames> userGame { get; set; }
        public DbSet<users> user { get; set; }
    }
}