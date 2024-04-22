using Domain.Articulos;
using Domain.Comentarios;
using Domain.Likes;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Likes
{
	public interface ILikeService
	{
		Result<IList<Like>> List();
        Result<Like> Get(int idLike);


        Result<int> Create(CreateLike createLike);

	}
}
