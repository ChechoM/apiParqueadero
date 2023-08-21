using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parqueadero.Data.Models;

namespace Parqueadero.Data
{
    public class PqDBContext : DbContext
    {
        public PqDBContext (DbContextOptions<PqDBContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; } = default!;
        public DbSet<UserRole> UserRole { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<Visita> Visita { get; set; } = default!;
        public DbSet<Calificaciones> Calificaciones { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            modelBuilder.Entity<UserRole>().ToTable(nameof(UserRole));
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<Visita>().ToTable(nameof(Visita));
            modelBuilder.Entity<Calificaciones>().ToTable(nameof(Calificaciones));

            base.OnModelCreating(modelBuilder);
        }
    }
}
