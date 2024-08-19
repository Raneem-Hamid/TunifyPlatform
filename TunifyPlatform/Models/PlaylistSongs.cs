namespace TunifyPlatform.Models
{
    public class PlaylistSongs
    {
        
        public int Playlist_ID { get; set; }

        public int Song_ID { get; set; }


        public Playlist Playlist { get; set; }
        public Song Song { get; set; }

    }
}
