using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comentarios
{
	public static class ComentarioErrors
	{
		public static Error NotFound() =>
			new Error("Comentarios.NOT_FOUND", $"The Comentario was not found.");

		public static Error NotCreated() =>
			new Error("Comentarios.NOT_CREATED", "The Comentario was not  created.");
	}
}
