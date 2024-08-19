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
using TunifyPlatform.Repositories.Services;

namespace TunifyPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistSongsController : ControllerBase
    {
        private readonly IPlayListSongs _playListSongs;

        public PlaylistSongsController(IPlayListSongs playListSongs)
        {
            _playListSongs = playListSongs;
        }

        // POST: api/Users

        [HttpPost("playlist/{playlistId}/song/{songId}")]
        public async Task<IActionResult> AddSongToPlayList(int songId, int playlistId)
        {
            try
            {
                await _playListSongs.AddSongToPlayList(songId, playlistId);
                return Ok(new { Message = "Song added to playlist successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("GetAllSongsInPlaylist")]
        public async Task<ActionResult<List<Song>>> GetAllSongsInPlaylist(int playlistId)
        {
            try
            {
                var songs = await _playListSongs.GetAllSongInList(playlistId);
                return Ok(songs);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


    }
}
