using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class ArtistService : IArtist
    {

        private readonly TunifyDbContext _context;

        public ArtistService(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Artist> CreateArtist(Artist artist)
        {
            _context.artist.Add(artist);

            await _context.SaveChangesAsync();

            return artist;
        }

        public async Task DeleteArtist(int artistId)
        {
            var getArtist = await GetArtistById(artistId);
            if (getArtist != null)
            {
                throw new KeyNotFoundException("Artist not found.");
            }
            else 
            { 
                _context?.artist.Remove(getArtist);
                await _context.SaveChangesAsync();
            }

            }

        public async Task<List<Artist>> GetAllArtists()
        {
            var allArtists = await _context.artist.ToListAsync(); 
            return allArtists;
        }

        public async Task<Artist> GetArtistById(int artistId)
        {
            var artist = await _context.artist.FindAsync(artistId);
            if (artist == null)
            {
                throw new KeyNotFoundException("Artist not found.");
            }
            else
            {
                return artist;
            }
        }

        public async Task<Artist> GetArtistByName(string artistName)
        {
            var artist = await _context.artist.FindAsync(artistName);
            if (artist == null)
            {
                throw new KeyNotFoundException("Artist not found.");
            }
            else
            {
                return artist;
            }
        }

        public async Task<Artist> UpdateArtist(int artistId, Artist artist)
        {
            var existingArtist = await _context.artist.FindAsync(artistId);
            if (existingArtist == null)
            {
                throw new KeyNotFoundException("Artist not found.");
            }
            else
            {
                existingArtist = artist;
                await _context.SaveChangesAsync();
                return artist;
            }
        }


       
            public async Task AddSongToArtist(int artistId, int songId)
            {
                var artist = await _context.artist.Include(a => a.song).FirstOrDefaultAsync(a => a.Id == artistId);
                var song = await _context.song.FindAsync(songId);

                if (artist != null && song != null)
                {
                    artist.song.Add(song);
                    await _context.SaveChangesAsync();
                }
            }
        

      

        public async Task<List<Song>> GetSongsByArtist(int artistId)
        {
            var artist = await _context.artist.Include(a => a.song).FirstOrDefaultAsync(a => a.Id == artistId);
            return artist?.song.ToList();
        }
    }
}
