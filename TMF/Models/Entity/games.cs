using System.Collections.Generic;

namespace TMF.Models.Entity
{
    public partial class games
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public byte[] image { get; set; }
        public List<userGames> userGame { get; set; }
        public List<gameComponents> gameComponent { get; set; }
        public List<gameGenres> gameGenre { get; set; }
        public List<gamePlatforms> gamePlatform { get; set; }
    }

}
