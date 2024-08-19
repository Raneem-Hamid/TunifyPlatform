using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Artist_ID { get; set; }
        public int Album_ID { get; set; }
        public TimeSpan Duration { get; set; }
        public string Genre { get; set; }

        public Artist artist { get; set; }

        public ICollection<PlaylistSongs> playlistSongs { get; set; }
    }
}
