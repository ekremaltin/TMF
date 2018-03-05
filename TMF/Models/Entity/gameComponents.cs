using System.Collections.Generic;

namespace TMF.Models.Entity
{
    public partial class gameComponents
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual games game { get; set; }
        public List<compAtts> compAtt { get; set; }
    }
}