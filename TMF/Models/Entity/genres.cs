﻿using System.Collections.Generic;

namespace TMF.Models.Entity
{
    public partial class genres
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<games> game { get; set; }
    }
}
