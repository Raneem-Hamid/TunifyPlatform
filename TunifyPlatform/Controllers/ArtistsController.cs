using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtist _artist;

        public ArtistsController(IArtist artist)
        {
            _artist = artist;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> Getartist()
        {
         return await _artist.GetAllArtists();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            return await _artist.GetArtistById(id);
        }


        // GET: api/Artists/name/artistName
        [HttpGet("name/{artistName}")]
        public async Task<ActionResult<Artist>> GetArtistByName(string artistName)
        {
            return await _artist.GetArtistByName(artistName);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            var updateArtist = await _artist.UpdateArtist(id, artist);
            return Ok(updateArtist);
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {

            var newArtist = await _artist.CreateArtist(artist);
            return Ok(newArtist);

        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
             
             await _artist.DeleteArtist(id);
            return NoContent();

        }

        //private bool ArtistExists(int id)
        //{
        //    return (_context.artist?.Any(e => e.Id == id)).GetValueOrDefault();
        //}

        [HttpPost("{artistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToArtist(int artistId, int songId)
        {
            await _artist.AddSongToArtist(artistId, songId);
            return Ok();
        }

        [HttpGet("{artistId}/songs")]
        public async Task<ActionResult<List<Song>>> GetSongsByArtist(int artistId)
        {
            var songs = await _artist.GetSongsByArtist(artistId);
            return Ok(songs);
        }
    }
}
