namespace Tunify_Platform
{
    public interface IUser
    {
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(int id, User user);
        Task DeleteUserAsync(int id);
    }
}