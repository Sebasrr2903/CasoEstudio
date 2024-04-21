using AutoMapper;
using Domain.Articulos;
using Shared;

namespace Application.Articulos
{
    public class ArticuloService : IArticuloService
    {
        private readonly IArticuloRepository _repository;
        private readonly IMapper _mapper;

        public ArticuloService(IArticuloRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Result<IList<Articulo>> List(bool includeComments = false)
		{
			return
				includeComments
					? Result.Success<IList<Articulo>>(_repository.GetAll(i => i.Comentario))
					: Result.Success<IList<Articulo>>(_repository.GetAll());
		}

     
        public Result Create(CreateArticulo createArticulo)
        {
            var articulo = _mapper.Map<CreateArticulo, Articulo>(createArticulo);
            _repository.Insert(Articulo.Create(0, articulo));
            _repository.Save();
            return Result.Success();
        }

       

     

    }
}
