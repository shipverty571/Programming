using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistOfSongs.Model
{
    public class SongAddedEventArgs : EventArgs
    {
        public SongAddedEventArgs(Song song)
        {
            Song = song;
        }

        public Song Song { get; set; }
    }
}
