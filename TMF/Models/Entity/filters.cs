namespace TMF.Models.Entity
{
    public partial class filters
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public virtual users user { get; set; }
    }
}