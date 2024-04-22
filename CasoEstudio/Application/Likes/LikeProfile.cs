using AutoMapper;
using Domain.Articulos;
using Domain.Comentarios;
using Domain.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Likes
{
	public class LikeProfile : Profile
	{
		public LikeProfile()
		{
			CreateMap<CreateLike, Like>();

			CreateMap<Like, LikeDTO>()
				.ConstructUsing(source =>
					new LikeDTO(source.IdL, source.Tipo));

		}
	}
}
