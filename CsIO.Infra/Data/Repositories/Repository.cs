using CsIO.Business.Core.Data;
using CsIO.Business.Core.Models;
using CsIO.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CsIO.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new ()
    {
        protected readonly CsIoContext csIOContext;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(CsIoContext context)
        {
            csIOContext = context;
            dbSet = csIOContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking()
                              .Where(predicate)
                              .ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            csIOContext.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }
        
        public virtual async Task Remover(Guid id)
        {
            csIOContext.Entry(new TEntity { Id = id }).State = EntityState.Deleted;
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await csIOContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            csIOContext?.Dispose();
        }
    }
}
