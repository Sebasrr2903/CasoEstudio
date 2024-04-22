﻿using Shared;
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

        public static Error AlreadyDone() =>
        new Error("Articulos.ALREADY_DONE", "The Articulo already has this comment.");

        public static Error AlreadyHasLike() =>
        new Error("Articulos.ALREADY_DONE", "The Articulo already has this like.");

    }
}
