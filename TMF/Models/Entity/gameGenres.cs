namespace TMF.Models.Entity
{
    public class gameGenres
    {
        public int id { get; set; }
        public virtual genres genre { get; set; }
        public virtual games game { get; set; }
    }
}