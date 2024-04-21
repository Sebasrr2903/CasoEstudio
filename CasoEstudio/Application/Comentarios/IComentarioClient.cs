using Domain.Articulos;
using Domain.Comentarios;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comentarios
{
	public interface IComentarioClient
	{
		Task<List<ComentarioDTO>> List();
		Task<Result> Create(CreateComentario createComentario);
	}
}
