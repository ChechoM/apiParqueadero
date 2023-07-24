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

        public DbSet<Parqueadero.Data.Models.Client> Client { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Client>().ToTable(nameof(Client));

            base.OnModelCreating(modelBuilder);
        }
    }
}
