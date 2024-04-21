using Application.Comentarios;
using AutoMapper;
using Domain.Articulos;
using Domain.Comentarios;
using Shared;

namespace Application.Articulos
{
    public class ArticuloService : IArticuloService
    {
        private readonly IArticuloRepository _repository;
        private readonly IComentarioService _comentarioService;
        private readonly IMapper _mapper;

        public ArticuloService(IArticuloRepository repository, IMapper mapper, IComentarioService comentarioService)
        {
            _repository = repository;
            _mapper = mapper;
            _comentarioService = comentarioService;
        }

        public Result<IList<Articulo>> List(bool includeComments = false)
		{
			return
				includeComments
					? Result.Success<IList<Articulo>>(_repository.GetAll(i => i.Comentario))
					: Result.Success<IList<Articulo>>(_repository.GetAll());
		}

        public Result<Articulo> Get(int id, bool includeComments = false)
        {
            var articulo =
                includeComments
                    ? _repository.Get(s => s.Id == id, i => i.Comentario)
                    : _repository.Get(s => s.Id == id);

            if (articulo is null)
            {
                return Result.Failure<Articulo>(ArticuloErrors.NotFound());
            }
            return Result.Success(articulo);
        }


        public Result Create(CreateArticulo createArticulo)
        {
            var articulo = _mapper.Map<CreateArticulo, Articulo>(createArticulo);
            _repository.Insert(Articulo.Create(0, articulo));
            _repository.Save();
            return Result.Success();
        }

        public Result AddComment(int id, int idComment)
        {
            // Obtener el artículo
            dynamic result = Get(id, true);
            if (!result.IsSuccess)
            {
                return Result.Failure<Articulo>(ArticuloErrors.NotFound());
            }
            var articulo = result.Value as Articulo;
            if (articulo.Comentario.Exists(e => e.IdC == idComment))  //Verificar que no se inserten dos veces el mismo comentario
            {
                return Result.Failure<Articulo>(ArticuloErrors.AlreadyDone());
            }

            //Obtener comentario
            result = _comentarioService.Get(idComment);
            if (!result.IsSuccess)
            {
                return Result.Failure<Comentario>(ComentarioErrors.NotFound());
            }

            var comentario = result.Value as Comentario;
            articulo.Comentario.Add(comentario);

            _repository.Update(articulo);
            _repository.Save();

            return Result.Success();
        }






    }
}
