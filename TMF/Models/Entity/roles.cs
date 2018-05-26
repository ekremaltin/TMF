using System.Collections.Generic;

namespace TMF.Models.Entity
{
    public partial class roles
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual List<users> user { get; set; }
    }
}
