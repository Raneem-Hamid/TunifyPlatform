using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class PlayListSongsService : IPlayListSongs
    {
        private readonly TunifyDbContext _context;

        public PlayListSongsService(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task AddSongToPlayList(int songId, int playListId)
        {
            var playlistSong = new PlaylistSongs
            {
                Playlist_ID = playListId,
                Song_ID = songId
            };

            _context.playlistSongs.Add(playlistSong);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Song>> GetAllSongInList( int playListId)
        {
            return await _context.playlistSongs
                .Where(ps => ps.Playlist_ID == playListId)
                .Select(ps => ps.Song)
                .ToListAsync();
        }
    }
}
