using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRepositoryBase<T>
        where T : Entity
    {
        List<T> GetAll();

        void Insert(T entity);

 

        void Save();

    }
}
