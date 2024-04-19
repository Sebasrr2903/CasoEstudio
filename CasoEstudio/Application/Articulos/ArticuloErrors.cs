using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Articulos
{
    public static class ArticuloErrors
    {
     
        public static Error NotFound() =>
            new Error("Articulos.NOT_FOUND", $"The Articulo was not found.");

		public static Error NotCreated() =>
			new Error("Articulos.NOT_CREATED", "The Articulo was not  created.");

	
	}
}
