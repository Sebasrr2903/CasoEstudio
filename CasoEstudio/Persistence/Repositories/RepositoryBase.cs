using Application.Contexts;
using Application.Repositories;
using Domain;
using Domain.Articulos;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : Entity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _entities;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public List<T> GetAll()
        {
			IQueryable<T> query = _entities;

			return query.ToList();
        }

        public void Insert(T entity)
        {
            _entities.Add(entity);
        }

      
        public void Save()
        {
            _context.Save();
        }


    }
}
