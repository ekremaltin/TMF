using System.Collections.Generic;

namespace TMF.Models.Games.Steam
{
    public class response
    {

        public int game_count { get; set; }
        public List<gameDesc> games { get; set; }
    }
}