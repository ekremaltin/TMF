using System.Collections.Generic;

namespace TMF.Models.Entity
{
    public partial class platforms
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<gamePlatforms> gamePlatform { get; set; }
    }
}
