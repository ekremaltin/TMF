using System;

namespace TMF.Models.Games.Steam
{
    public class gameDesc
    {
        public int appid { get; set; }
        public string name { get; set; }
        public int playtime_forever { get; set; }
        public string img_icon_url { get; set; }
        public string img_logo_url { get; set; }
        public Boolean has_community_visible_stats { get; set; }
    }
}