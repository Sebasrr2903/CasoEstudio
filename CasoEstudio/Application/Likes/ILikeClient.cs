using Domain.Articulos;
using Domain.Comentarios;
using Domain.Likes;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comentarios
{
	public interface ILikeClient
	{
		Task<List<LikeDTO>> List();
		Task<Result> Create(CreateLike createLike);
	}
}
