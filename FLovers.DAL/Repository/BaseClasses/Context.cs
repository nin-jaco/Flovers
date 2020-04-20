using System.Data.Entity;
using Audit.EntityFramework;
using FLovers.DAL.Repository.Interfaces;

namespace FLovers.DAL.Repository.BaseClasses
{
    public class Context<TEntity> : IContext<TEntity> where TEntity : class
    {
        public Context()
        {
            DbContext = new AuditDb.FLoversEntities();
            DbSet = DbContext.Set<TEntity>();
        }

        public Context(AuditDbContext db)
        {
            DbContext = db;
            DbSet = DbContext.Set<TEntity>();
        }

        public AuditDbContext DbContext { get; set; }

        public IDbSet<TEntity> DbSet { get; set; }


        public void Dispose()
        {
            DbContext.Dispose();
        }

    }

}
