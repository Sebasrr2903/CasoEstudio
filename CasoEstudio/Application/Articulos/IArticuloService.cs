using Domain.Articulos;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Articulos
{
    public interface IArticuloService
    {
        Result<IList<Articulo>> List(bool includeComments = false);

        Result<Articulo> Get(int Id, bool includeComments = false);

        Result Create(CreateArticulo createArticulo);

        Result AddComment(int id, int idC);

     
    }
}
