using System.Collections.Generic;

namespace TMF.Models.Entity
{
    public partial class userGames
    {
        public int id { get; set; }
        public virtual users user { get; set; }
        public virtual games game { get; set; }
        public int time { get; set; }
        public string gameNickName { get; set; }
        public string gameConnectID { get; set; }
        public virtual List<userGameDescs> userGameDesc { get; set; }
    }
}
