using Microsoft.EntityFrameworkCore;
using Parqueadero.Data;
using Parqueadero.Data.Enumerations;
using Parqueadero.Data.Models;

public class SeedDb
{
    private readonly PqDBContext context;
    private readonly Random random;

    public SeedDb(PqDBContext context)
    {
        this.context = context;
        this.random = new Random();
    }

    public async Task SeedAsync()
    {
        await this.context.Database.EnsureCreatedAsync();

        if (!this.context.Client.Any())
        {
            this.AddClient("First Client");
            this.AddClient("Second Client");
            this.AddClient("Third Client");
            await this.context.SaveChangesAsync();
        }

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

        await this.context.Database.MigrateAsync();
    }

    private void AddClient(string name)
    {
        this.context.Client.Add(new Client
        {
            Name = name,
            Dna = this.random.Next(1000000, 1999999).ToString()
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
}
