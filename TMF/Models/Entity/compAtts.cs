using System.Collections.Generic;

namespace TMF.Models.Entity
{
    public partial class compAtts
    {
        public int id { get; set; }        
        public string value { get; set; }
        public string value2 { get; set; }
        public virtual gameComponents gameComponent {get; set;}
        public List<userGameDescs> userGameDesc { get; set; }
    }
}
