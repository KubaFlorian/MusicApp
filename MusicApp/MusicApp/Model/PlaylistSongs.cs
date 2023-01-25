using System;
using System.Collections.Generic;
using System.Text;

namespace MusicApp.Model
{
    public class PlaylistSongs
    {
        public int id { get; set; }
        public int playlistId { get; set; }
        public int songId { get; set; }
    }
}
