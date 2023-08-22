using Microsoft.EntityFrameworkCore;
using Parqueadero.Data;
using Parqueadero.Data.Dto;
using Parqueadero.Data.Enumerations;
using Parqueadero.Data.Mock;
using Parqueadero.Data.Models;
using System.Runtime.InteropServices;

public class SeedDb
{
    private readonly PqDBContext context;
    private readonly Random random;
    private readonly MockParqueaderoDto mockParqueaderoDto;

    public SeedDb(PqDBContext context)
    {
        this.context = context;
        this.random = new Random();
        this.mockParqueaderoDto = new MockParqueaderoDto();
    }

    public async Task SeedAsync()
    {
        await this.context.Database.EnsureCreatedAsync();

        

        if (!this.context.UserRole.Any())
        {
            this.AddUserRole("Administrator", RoleType.SuperAdmin);
            this.AddUserRole("Staff", RoleType.Staff);
            this.AddUserRole("Guest", RoleType.Guest);
            await this.context.SaveChangesAsync();
        }

        if (!this.context.User.Any())
        {
            this.AddUser("AdminUser", "123", 1);
            this.AddUser("StaffUser", "123", 2);
            this.AddUser("GuestUser", "123", 3);
            await this.context.SaveChangesAsync();
        }
        if (!this.context.Client.Any())
        {
            List<ParqueaderoDto> valoresParqueadero = this.mockParqueaderoDto.getMockParqueadero();
            
            List<long> idUsers = this.context.User.Select(x => x.Id).ToList();
            foreach (ParqueaderoDto item in valoresParqueadero)
            {
                this.AddClient(idUsers[this.random.Next(1, idUsers.Count)], item.Nombre, item.Descripcion, item.Direccion);               
                
            }
            await this.context.SaveChangesAsync();
        }
              

        if (!this.context.Visita.Any())
        {
            List<long> idClientes = this.context.Client.Select(x => x.Id).ToList();

            foreach (var item in idClientes)
            {
                for (int i = 0; i < 10; i++)
                {
                    this.AddVisita(item);
                }
            }

            await this.context.SaveChangesAsync();
        }

        if (!this.context.Calificaciones.Any())
        {
            List<long> idVisitas = this.context.Visita.Select(x => x.Id).ToList();
            List<string> comentarios = this.mockParqueaderoDto.getComentarios();
            foreach (var item in idVisitas)
            {
                this.AddCalificacion(comentarios[this.random.Next(1, comentarios.Count)], item);
            }

            await this.context.SaveChangesAsync();
        }

        await this.context.Database.MigrateAsync();
    }

    private void AddClient(long idUser, string name, string descrpcion = "Falta descripcion", string direccion = "Falta direccion")
    {
        
        this.context.Client.Add(new Client
        {
            Name = name,
            UserId = idUser,
            Nit = this.random.Next(1000000, 1999999).ToString(),
            Datafono = Convert.ToBoolean(this.random.Next(-1, 0)),
            Descripcion = descrpcion,
            Direccion = direccion,
            Disponibilidad = Convert.ToBoolean(this.random.Next(-1, 0)),
            HorarioAbre = DateTime.Now.AddHours(this.random.Next(0, 24)),
            HorarioCierre = DateTime.Now.AddHours(this.random.Next(0, 24)),
            Techo = Convert.ToBoolean(this.random.Next(-1, 0)),
            ValorHora = this.random.Next(1000, 5000),
            Latitud = $"6.2{this.random.Next(Convert.ToInt32(5494), Convert.ToInt32(95494))}0026729888",
            Longitud = $"-75.5{ this.random.Next(Convert.ToInt32(814), Convert.ToInt32(90627))}40627"
        });

    }

    private void AddUserRole(string roleName, RoleType roleType)
    {
        this.context.UserRole.Add(new UserRole
        {
            Name = roleName,
            Type = roleType
        });
    }

    private void AddUser(string userId, string password, long userRoleId)
    {
        this.context.User.Add(new User
        {
            UserName = userId,
            Password = password,
            RoleId = userRoleId
        });
    }

    public void AddVisita(long idClient)
    {
        this.context.Visita.Add(new Visita
        {
            ClientId = idClient,
            CodigoVisita = this.random.Next(0, 100).ToString(),       

        });
    }

    public void AddCalificacion(string comentario, long idVisita)
    {
        this.context.Calificaciones.Add(new Calificaciones
        {
            Calificacion = this.random.Next(1,5),
            Comentario = comentario,
            IdVisita = idVisita
        });
    }
}
