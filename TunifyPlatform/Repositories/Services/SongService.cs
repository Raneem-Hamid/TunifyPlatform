using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class SongService : ISong
    {
        private readonly TunifyDbContext _context;

        public SongService(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Song> AddSong(Song song)
        {
            _context.song.Add(song);

            await _context.SaveChangesAsync();

            return song;
        }

        public async Task DeleteSong(int songId)
        {

            var getSong = await GetSongById(songId);
            if (getSong != null)
            {
                throw new KeyNotFoundException("This Song is not found.");
            }
            else
            {
                _context.song.Remove(getSong);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Song>> GetAllSongs()
        {
            var allSongs = await _context.song.ToListAsync();
            return allSongs;
        }

        public async Task<Song> GetSongById(int songId)
        {
            var song = await _context.song.FindAsync(songId);
            if (song == null)
            {
                throw new KeyNotFoundException("This Song is not found.");
            }
            else
            {
                return song;
            }
        }

        public async Task<Song> UpdateSong(int songId, Song song)
        {
            var existingSongt = await _context.song.FindAsync(songId);
            if (existingSongt == null)
            {
                throw new KeyNotFoundException("This Song is not found.");
            }
            else
            {
                existingSongt = song;
                await _context.SaveChangesAsync();
                return song;
            }
        }
    }
}
