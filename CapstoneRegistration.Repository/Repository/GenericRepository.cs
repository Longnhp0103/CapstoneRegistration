﻿using CapstoneRegistration.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneRegistration.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CapstoneRigistrationContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(CapstoneRigistrationContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public GenericRepository(CapstoneRigistrationContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Delete(object id)
        {
            T exist = _dbSet.Find(id);
            if (exist != null)
            {
                _dbSet.Remove(exist);
            }
            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);

        }

        public void Insert(T obj)
        {
            _dbSet.Add(obj);
            _dbContext.SaveChanges();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void Update(T obj)
        {
            _dbContext.Update(obj);
            _dbContext.SaveChanges();
        }

    }
}

