using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform;
using Tunify_Platform.Data;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylist _playlist;
        private readonly ISong _song;
        public PlaylistsController(IPlaylist playlist, ISong song)
        {
            _playlist = playlist;
            _song = song;
        }

        // GET: api/Playlists
        [Route("/playlists/getAll")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            return await _playlist.GetAllAsync();
        }

        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(int id)
        {
            return await _playlist.GetByIdAsync(id);
        }

        // PUT: api/Playlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist(int id, Playlist Playlist)
        {
            var updatePlaylist = await _playlist.UpdateAsync(id, Playlist);
            return Ok(updatePlaylist);
        }

        // POST: api/Playlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist Playlist)
        {
            var newPlaylist = await _playlist.InsertAsync(Playlist);
            return Ok(newPlaylist);
        }

        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var deletedEmployee = _playlist.DeleteAsync(id);
            return Ok(deletedEmployee);
        }
        // POST: api/playlists/{playlistId}/songs/{songId}
        [HttpPost("{playlistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToPlaylist(int playlistId, int songId)
        {
            await _playlist.AddSongToPlaylistAsync(playlistId, songId);
            return Ok();
        }

        [HttpGet("{playlistId}/songs")]
        public async Task<IActionResult> GetSongsInPlaylist(int playlistId)
        {
            var songs = await _playlist.GetSongsInPlaylistAsync(playlistId);
            return Ok(songs);
        }
    }
}