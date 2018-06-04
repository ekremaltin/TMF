using System.Collections.Generic;

namespace TMF.Models.Entity
{
    public partial class games
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public byte[] image { get; set; }
        public virtual List<userGames> userGame { get; set; }
        public virtual List<gameComponents> gameComponent { get; set; }
        public virtual List<gameGenres> gameGenre { get; set; }
        public virtual List<gamePlatforms> gamePlatform { get; set; }
        public virtual List<lobbys> lobby { get; set; }
    }

}
