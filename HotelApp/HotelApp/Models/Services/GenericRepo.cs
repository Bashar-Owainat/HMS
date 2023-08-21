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
       

        public virtual async Task<List<TEntity>> GetAll()
        {
            var list = await dbSet.ToListAsync();
            await _context.SaveChangesAsync();
            return list;
        }

        public async Task<TEntity> GetById(object id)
        {
            var room = await dbSet.FindAsync(id);
            return room;
        }

        public async Task<TEntity> Insert(TEntity obj)
        {
            dbSet.Add(obj);
            await _context.SaveChangesAsync();
            return obj; 
        }

        public async Task<TEntity> Update(object id, TEntity entityToUpdate)
        {
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entityToUpdate;
        }

        public async Task Delete(object id)
        {
            var entityToDelete = await dbSet.FindAsync(id);
            dbSet.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
