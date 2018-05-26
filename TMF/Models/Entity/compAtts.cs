using System.Collections.Generic;

namespace TMF.Models.Entity
{
    public partial class compAtts
    {
        public int id { get; set; }        
        public string value { get; set; }
        public virtual gameComponents gameComponent {get; set;}
        public virtual List<userGameDescs> userGameDesc { get; set; }
    }
}
