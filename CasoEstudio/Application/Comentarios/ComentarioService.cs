using Application.Articulos;
using AutoMapper;
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
	public class ComentarioService : IComentarioService
	{
		private readonly IComentarioRepository _repository;
		private readonly IMapper _mapper;

		public ComentarioService(IComentarioRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public Result Create(CreateComentario createComentario)
		{
			var comentario = _mapper.Map<CreateComentario, Comentario>(createComentario);
			_repository.Insert(Comentario.Create(0, comentario));
			_repository.Save();
			return Result.Success();
		}

		public Result<IList<Comentario>> List()
		{
			return Result.Success<IList<Comentario>>(_repository.GetAll());

		}
	}
}
