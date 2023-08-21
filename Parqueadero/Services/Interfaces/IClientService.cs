using Parqueadero.Data.Models;

namespace Parqueadero.Services.Interfaces
{
    public interface IClientService
    {
        public  UserRole ValidaPermisos(long id);
    }
}
