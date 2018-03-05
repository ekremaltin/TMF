using System.Collections.Generic;

namespace TMF.Models.Entity
{
    public partial class roles
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<users> user { get; set; }
    }
}
