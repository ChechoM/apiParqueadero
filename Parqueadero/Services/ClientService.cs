using Parqueadero.Data;
using Parqueadero.Data.Models;
using Parqueadero.Services.Interfaces;

namespace Parqueadero.Services
{
    public class ClientService: IClientService
    {
        private readonly PqDBContext _context;
        public ClientService(PqDBContext context) 
        {
            this._context = context;
        }

        public UserRole ValidaPermisos(long id)
        {

            UserRole? role = this._context.Client.Where(x => x.Id == id).Select(x => new UserRole()
            {
                Name = x.User.Role.Name,
                RoleId = x.User.Role.RoleId,
                Type = x.User.Role.Type,
            }).FirstOrDefault();

            return role;

        }

    }
}
