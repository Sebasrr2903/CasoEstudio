using AutoMapper;
using Domain.Articulos;
using Domain.Comentarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comentarios
{
	public class ComentarioProfile : Profile
	{
		public ComentarioProfile()
		{
			CreateMap<CreateComentario, Comentario>();

			CreateMap<Comentario, ComentarioDTO>()
				.ConstructUsing(source =>
					new ComentarioDTO(source.IdC, source.Fecha, source.Comment));

		}
	}
}
