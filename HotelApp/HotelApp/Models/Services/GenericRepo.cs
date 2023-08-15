using HotelApp.Data;
using HotelApp.Migrations;
using HotelApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelApp.Models.Services
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        internal HotelDbContext _context;
        internal DbSet<TEntity> dbSet;

        public GenericRepo(HotelDbContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }
       

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var list = await dbSet.ToListAsync();
            await _context.SaveChangesAsync();
            return list;
        }

        public TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public async Task<TEntity> Insert(TEntity obj)
        {
            dbSet.Add(obj);
            await _context.SaveChangesAsync();
            return obj; 
        }

        public TEntity Update(TEntity entityToUpdate)
        {
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            return entityToUpdate;
        }

        public void Delete(object id)
        {
            var entityToDelete = dbSet.Find(id);
            dbSet.Remove(entityToDelete);
        }
    }
}
