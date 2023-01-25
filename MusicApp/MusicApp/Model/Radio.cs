using System;
using System.Collections.Generic;
using System.Text;

namespace MusicApp.Model
{
    public class Radio
    {
        public int radioId { get; set; }
        public string radioName { get; set; }
        public string radioUrl { get; set; }
        public string radioCover { get; set; }
        public bool? IsRecent { get; set; }
    }
}
