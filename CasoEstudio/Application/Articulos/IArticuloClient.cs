using Domain.Articulos;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Articulos
{
    public interface IArticuloClient
    {
        Task<List<ArticuloDTO>> List();
        Task<Result> Create(CreateArticulo createArticulo);

    }
}
