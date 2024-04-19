
using Domain.Articulos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Articulo> Articulos { get; set; }
    
        void Save();
    }
}
