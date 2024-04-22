using Application.Comentarios;
using Application.Likes;
using AutoMapper;
using Domain.Articulos;
using Domain.Comentarios;
using Domain.Likes;
using Shared;
using System.Xml.Linq;

namespace Application.Articulos
{
    public class ArticuloService : IArticuloService
    {
        private readonly IArticuloRepository _repository;
        private readonly ILikeRepository _likeRepository;

        private readonly IComentarioService _comentarioService;
        private readonly ILikeService _likeService;

        private readonly IMapper _mapper;

        public ArticuloService(IArticuloRepository repository, IMapper mapper, IComentarioService comentarioService, ILikeService likeService)
        {
            _repository = repository;
            _mapper = mapper;
            _comentarioService = comentarioService;
            _likeService = likeService;
        }

        public Result<IList<Articulo>> List(bool includeComments = false, bool includeLikes = false)
        {
            return includeComments
                ? Result.Success<IList<Articulo>>(includeLikes
                    ? _repository.GetAll(i => i.Comentario, i => i.Like)
                    : _repository.GetAll(i => i.Comentario))
                : Result.Success<IList<Articulo>>(includeLikes
                    ? _repository.GetAll(i => i.Like)
                    : _repository.GetAll());
        }

        public Result<Articulo> Get(int id, bool includeComments = false, bool includeLikes = false)
        {
            return includeComments
                ? Result.Success(includeLikes
                    ? _repository.Get(s => s.Id == id, i => i.Comentario, i => i.Like)
                    : _repository.Get(s => s.Id == id, i => i.Comentario))
                : Result.Success(includeLikes
                    ? _repository.Get(s => s.Id == id, i => i.Like)
                    : _repository.Get(s => s.Id == id));
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

        public Result AddLike(int idArticulo, int idLike)
        {
            // Obtener el artículo
            var result = Get(idArticulo, false, true);
            if (!result.IsSuccess)
            {
                return Result.Failure<Articulo>(ArticuloErrors.NotFound());
            }
            var articulo = result.Value as Articulo;

            if (articulo.Like == null)
            {
                articulo.Like = new List<Like>();
            }

            // Verificar si el like ya existe en el artículo
            var likeExistente = articulo.Like.FirstOrDefault(e => e.IdL == idLike);

            if (likeExistente != null)
            {
                // Obtener tipo del nuevo like
                var likeResult = _likeService.Get(idLike);
                if (!likeResult.IsSuccess)
                {
                    return Result.Failure<Like>(LikeErrors.NotFound());
                }

                var nuevoLike = likeResult.Value as Like;
                char tipoNuevo = nuevoLike.Tipo;

                // Si los tipos son diferentes, actualizar el tipo del like existente
                if (likeExistente.Tipo != tipoNuevo)
                {
                    likeExistente.Tipo = tipoNuevo;

                    _likeRepository.Update(likeExistente);
                    _repository.Update(articulo);

                    _repository.Save();

                    return Result.Success("Tipo de like actualizado con éxito.");
                }
                else
                {
                    // Si los tipos son iguales, no se realiza ninguna acción
                    return Result.Failure<Articulo>(ArticuloErrors.AlreadyHasLike());
                }
            }
            else
            {
                var resultado = _likeService.Get(idLike);

                var like = resultado.Value as Like;
                articulo.Like.Add(like);

                _repository.Update(articulo);
                _repository.Save();

                return Result.Success("Nuevo like agregado al artículo.");
            }
        }







    }
}
