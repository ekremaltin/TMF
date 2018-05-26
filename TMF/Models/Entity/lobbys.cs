using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMF.Models.Entity
{
    public class lobbys
    {
        public int id { get; set; }
        public virtual users userGon { get; set; }        
        public virtual users userAl { get; set; }
        public DateTime date { get; set; }
        public bool status { get; set; }
        public int gameID { get; set; }
    }
}