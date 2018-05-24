using System;
using System.Collections.Generic;

namespace TMF.Models.Entity
{
    public partial class users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public DateTime dateOfBirth { get; set; }
        public byte[] image { get; set; }
        public bool mic { get; set; }
        public bool headset { get; set; }
        public bool online { get; set; }
        public bool search { get; set; }
        public List<filters> filter { get; set; }
        public List<userGames> userGame { get; set; }
        public virtual roles role { get; set; }
    }
}
