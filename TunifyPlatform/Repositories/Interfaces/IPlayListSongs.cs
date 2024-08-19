using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IPlayListSongs
    {

        Task AddSongToPlayList(int songId , int playListId);

        Task<List<Song>> GetAllSongInList( int playListId);
    }
}
