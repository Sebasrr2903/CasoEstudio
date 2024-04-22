using Application.Repositories;
using Domain.Comentarios;
using Domain.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Likes
{
	public interface ILikeRepository : IRepositoryBase<Like>
	{
	}
}
