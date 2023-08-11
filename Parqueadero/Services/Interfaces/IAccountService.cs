
using Parqueadero.Data.Models;

namespace Parqueadero.Services
{
    public interface IAccountService
    {
        string GenerateJwtToken(User user);
    }
}