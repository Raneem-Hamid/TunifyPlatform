using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface ISong
    {
        Task<List<Song>> GetAllSongs();
        Task<Song> GetSongById(int songId);
        Task<Song> AddSong(Song song);
        Task<Song> UpdateSong(int songId , Song song);
        Task DeleteSong(int songId);
    }
}
