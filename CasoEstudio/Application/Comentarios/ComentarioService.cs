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

		public Result<int> Create(CreateComentario createComentario)
		{
			var comentario = _mapper.Map<CreateComentario, Comentario>(createComentario);
			_repository.Insert(Comentario.Create(0, comentario));
			_repository.Save();

			var comentarioInsertado = _repository.GetAll().LastOrDefault();

			return Result.Success(comentarioInsertado.IdC);
		}

		public Result<IList<Comentario>> List()
		{
			return Result.Success<IList<Comentario>>(_repository.GetAll());

		}

        public Result<Comentario> Get(int idComment)
        {
            var comentario = _repository.Get(s => s.IdC == idComment);

			if(comentario == null)
			{
				return Result.Failure<Comentario>(ComentarioErrors.NotFound());
			}

			return Result.Success<Comentario>(comentario);
				
        }
    }
}
