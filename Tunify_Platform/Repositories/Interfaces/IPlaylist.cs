namespace Tunify_Platform
{
    public interface IPlaylist
    {
        Task<List<Playlist>> GetAllAsync();
        Task<Playlist> GetByIdAsync(int playlistId);
        Task<Playlist> InsertAsync(Playlist playlist);
        Task<Playlist> UpdateAsync(int id, Playlist playlist);
        Task<Playlist> DeleteAsync(int playlistId);
        Task AddSongToPlaylistAsync(int playlistId, int songId);
        Task<IEnumerable<Song>> GetSongsInPlaylistAsync(int playlistId);
    }
}
