using Application.Contexts;
using Domain.Articulos;
using Domain.Comentarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Articulo> Articulos { get; set; }

		public DbSet<Comentario> Comentarios { get; set; }



		public void Save()
        {
            this.SaveChanges();
        }
    }
}
