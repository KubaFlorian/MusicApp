using System;
using System.Collections.Generic;
using System.Text;

namespace MusicApp.Model
{
    public class Music
    {
        public int songId { get; set; }
        public string songName { get; set; }
        public string songFileCover { get; set; } = "https://usercontent2.hubstatic.com/14548043_f1024.jpg";
        public string songUrl { get; set; }
        public TimeSpan songDuration { get; set; }
        public string singerName { get; set; }
        public bool? IsRecent { get; set; }
    }
}
