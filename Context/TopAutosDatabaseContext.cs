using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopAutos.Models;

namespace TopAutos.Context
{
    public class TopAutosDatabaseContext : DbContext
    {
        public
        TopAutosDatabaseContext(DbContextOptions<TopAutosDatabaseContext> options)
        : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<VehiculoFavUsuario> VehiculoFavUsuario { get; set; }
        public DbSet<VotosUsuario> VotosUsuario { get; set; }

    }
}
