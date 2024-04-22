using Application.Likes;
using Domain.Likes;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Likes
{
    public class LikeRepository : RepositoryBase<Like>, ILikeRepository
    {
        public LikeRepository(ApplicationDbContext context)
            : base(context)
        { }
    
    }
}
