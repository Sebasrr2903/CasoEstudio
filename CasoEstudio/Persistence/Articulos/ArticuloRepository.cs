using Application.Contexts;
using Application.Articulos;
using Domain.Articulos;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Articulos
{
    public class ArticuloRepository : RepositoryBase<Articulo>, IArticuloRepository
    {
        public ArticuloRepository(ApplicationDbContext context)
            : base(context)
        {}
    }
}
