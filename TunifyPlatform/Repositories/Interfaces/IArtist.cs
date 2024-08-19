using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IArtist
    {
        Task<Artist> CreateArtist (Artist artist);
        
        Task<Artist> GetArtistById (int artistId);

        Task<Artist> GetArtistByName(string artistName);

        Task <List<Artist>> GetAllArtists ();

        Task<Artist> UpdateArtist (int artistId , Artist artist);

        Task DeleteArtist(int artistId);

        Task AddSongToArtist(int artistId, int songId);  

        Task<List<Song>> GetSongsByArtist(int artistId);


    }
}
