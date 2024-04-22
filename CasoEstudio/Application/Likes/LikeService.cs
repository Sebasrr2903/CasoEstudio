
using Application.Likes;
using AutoMapper;
using Domain.Likes;
using Shared;


namespace Application.Likes
{
	public class LikeService : ILikeService
	{
		private readonly ILikeRepository _repository;
		private readonly IMapper _mapper;

		public LikeService(ILikeRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public Result<int> Create(CreateLike createLike)
		{
			var like = _mapper.Map<CreateLike, Like>(createLike);
			_repository.Insert(Like.Create(0, like));
			_repository.Save();

			var likeInsertado = _repository.GetAll().LastOrDefault();

			return Result.Success(likeInsertado.IdL);
		}

		public Result<IList<Like>> List()
		{
			return Result.Success<IList<Like>>(_repository.GetAll());

		}

        public Result<Like> Get(int idLike)
        {
            var like = _repository.Get(s => s.IdL == idLike);

			if(like == null)
			{
				return Result.Failure<Like>(LikeErrors.NotFound());
			}

			return Result.Success<Like>(like);
				
        }
    }
}
