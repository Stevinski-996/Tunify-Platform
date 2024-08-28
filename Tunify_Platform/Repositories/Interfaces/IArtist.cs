namespace Tunify_Platform
{
    public interface IArtist
    {
        Task<List<Artist>> GetAllAsync();
        Task<Artist> GetByIdAsync(int artistId);
        Task<Artist> InsertAsync(Artist artist);
        Task<Artist> UpdateAsync(int id, Artist artist);
        Task DeleteAsync(int artistId);
        Task AddSongToArtistAsync(int artistId, int songId);
        Task<IEnumerable<Song>> GetSongsByArtistAsync(int artistId);
    }
}
