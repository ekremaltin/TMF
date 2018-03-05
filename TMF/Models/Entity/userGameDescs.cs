namespace TMF.Models.Entity
{
    public partial class userGameDescs
    {
        public int id { get; set; }
        public virtual userGames userGame { get; set; }
        public virtual compAtts compAtt { get; set; }
    }
}
