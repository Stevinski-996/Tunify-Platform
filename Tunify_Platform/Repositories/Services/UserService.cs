using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;

namespace Tunify_Platform
{
        public class UserService : IUser
        {
            private readonly TunifyDBContext _context;

            public UserService(TunifyDBContext context)
            {
                _context = context;
            }

            public async Task<List<User>> GetAllUsersAsync()
            {
                var allUsers = await _context.Users.ToListAsync();
                return allUsers;
            }

            public async Task<User> GetUserByIdAsync(int id) => await _context.Users.FindAsync(id);

            public async Task<User> AddUserAsync(User User)
            {
                _context.Users.Add(User);
                await _context.SaveChangesAsync();
                return User;
            }

            public async Task<User> UpdateUserAsync(int id, User User)
            {
                var exsitingEmployee = await _context.Users.FindAsync(id);
                exsitingEmployee = User;
                await _context.SaveChangesAsync();
                return User;
            }

            public async Task DeleteUserAsync(int id)
            {
                var getUser = await GetUserByIdAsync(id);
                _context.Entry(getUser).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
    }
}