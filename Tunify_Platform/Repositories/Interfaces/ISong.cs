namespace Tunify_Platform
{
    public interface ISong
    {
        Task<List<Song>> GetAllAsync();
        Task<Song> GetByIdAsync(int songId);
        Task<Song> InsertAsync(Song song);
        Task<Song> UpdateAsync(int id, Song song);
        Task<Song> DeleteAsync(int songId);
    }
}