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
	public interface IComentarioService
	{
		Result<IList<Comentario>> List();
        Result<Comentario> Get(int Id);


        Result Create(CreateComentario createComentario);

	}
}
