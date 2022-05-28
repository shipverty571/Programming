using System;

namespace PlaylistOfSongs.Model
{
    public class SongAddedEventArgs : EventArgs
    {
        /// <summary>
        /// Создаёт экземпляр класса <see cref="SongAddedEventArgs"/>.
        /// </summary>
        /// <param name="song">Песня.</param>
        public SongAddedEventArgs(Song song)
        {
            Song = song;
        }

        /// <summary>
        /// Возвращает и задаёт песню.
        /// </summary>
        public Song Song { get; set; }
    }
}
