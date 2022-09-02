using DAW.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly Context _context;
        public GenericRepository(Context context)
        {
            _context = context;
        }
        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
            //nu alterez BD, alterand datele de la GetAll. 
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
            //async -> requestul elibereaza threadul si il executa, comunicand cu BD.
            //await -> asteapta raspuns de la DB si il trimite mai departe.
        }

        public async Task<bool> SaveAsync()
        {
            //functiile de mai sus (fara async) se realizeaza in memorie, abia la un save se altereaza BD-ul.
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
//  iQueryable    -> doar un query sql(de fiecare data cand e folosit), nu datele in sine
//  iEnumerable   -> acelasi lucru, dar salveaza in memorie, nu face query mere
//  List          -> datele propriu zise, in memorie.