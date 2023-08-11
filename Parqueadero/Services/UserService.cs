using Microsoft.EntityFrameworkCore;
using Parqueadero.Data;
using Parqueadero.Data.Models;

namespace Parqueadero.Services
{
    public class UserService : IUserService
    {
        private readonly PqDBContext _context;

        public UserService(PqDBContext context)
        {
            _context = context;
        }

        public async Task<User>? GetUserAsync(string username, string password)
        {
            if (_context.User == null)
            {
                return null;
            }
            var user = await _context.User.FirstOrDefaultAsync(user => user.UserName == username && user.Password == password);

            return user;
        }
    }

}