using Application.Repositories;
using Domain.Articulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Articulos
{
    public interface IArticuloRepository : IRepositoryBase<Articulo>
    {
    }
}
