namespace TMF.Models.Entity
{
    public class gamePlatforms
    {
        public int id { get; set; }
        public virtual platforms platform { get; set; }
        public virtual games game { get; set; }        
    }
}