using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        public string PlayList_Name { get; set; }

        public DateTime Created_Date { get; set; }
        public int User_ID { get; set; }

        public ICollection<PlaylistSongs> playlistSongs { get; set; }
    }
}
