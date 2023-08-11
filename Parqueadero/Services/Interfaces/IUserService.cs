using Parqueadero.Data.Models;

namespace Parqueadero.Services
{
    public interface IUserService
    {
        Task<User>? GetUserAsync(string username, string password);
    }
}