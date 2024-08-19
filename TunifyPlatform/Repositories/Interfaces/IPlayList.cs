using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IPlayList
    {
        Task<List<Playlist>> GetAllPlaylists();
        Task<Playlist> GetPlaylistById(int playlistId);
        Task<Playlist> AddPlaylist(Playlist playlist);
        Task<Playlist> UpdatePlaylist(int playlistId ,Playlist playlist);

        Task DeletePlaylist(int playlistId);
    }
}
