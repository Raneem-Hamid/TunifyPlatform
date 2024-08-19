using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class PlayListService : IPlayList
    {
        private readonly TunifyDbContext _context;

        public PlayListService(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Playlist> AddPlaylist(Playlist playlist)
        {
            _context.playlist.Add(playlist);

            await _context.SaveChangesAsync();

            return playlist;
        }

        public async Task DeletePlaylist(int playlistId)
        {
            var getPlayList = await GetPlaylistById(playlistId);
            if (getPlayList != null)
            {
                throw new KeyNotFoundException("The PlayList is not found.");
            }
            else
            {
                _context.playlist.Remove(getPlayList);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Playlist>> GetAllPlaylists()
        {
            var allPlayLists = await _context.playlist.ToListAsync();
            return allPlayLists;
        }

        public  async Task<Playlist> GetPlaylistById(int playlistId)
        {
            var playlist = await _context.playlist.FindAsync(playlistId);
            if (playlist == null)
            {
                throw new KeyNotFoundException("The PlayList is not found.");
            }
            else
            {
                return playlist;
            }
        }

        public async Task<Playlist> UpdatePlaylist(int playlistId ,Playlist playlist)
        {
            var existingPlayList = await _context.playlist.FindAsync(playlistId);
            if (existingPlayList == null)
            {
                throw new KeyNotFoundException("The PlayList is not found.");
            }
            else
            {
                existingPlayList = playlist;
                await _context.SaveChangesAsync();
                return playlist;
            }
        }
    }
}
