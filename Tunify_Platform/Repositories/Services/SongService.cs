using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;

namespace Tunify_Platform
{
    public class SongService : ISong
    {
        private readonly TunifyDBContext _context;

        public SongService(TunifyDBContext context)
        {
            _context = context;
        }

        public async Task<List<Song>> GetAllAsync()
        {
            var allSongs = await _context.Songs.ToListAsync();
            return allSongs;
        }

        public async Task<Song> GetByIdAsync(int SongId) => await _context.Songs.FindAsync(SongId);

        public async Task<Song> InsertAsync(Song Song)
        {
            _context.Songs.Add(Song);
            await _context.SaveChangesAsync();
            return Song;
        }

        public async Task<Song> UpdateAsync(int id, Song Song)
        {
            var exsitingEmployee = await _context.Songs.FindAsync(id);
            exsitingEmployee = Song;
            await _context.SaveChangesAsync();
            return Song;
        }

        public async Task<Song> DeleteAsync(int id)
        {
            var Song = await GetByIdAsync(id);
            _context.Entry(Song).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return Song;
        }
    }
}