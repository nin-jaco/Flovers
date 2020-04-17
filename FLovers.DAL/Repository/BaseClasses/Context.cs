using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Audit.EntityFramework;
using FLovers.DAL.Repository.Interfaces;

namespace FLovers.DAL.Repository.BaseClasses
{
    public class Context<TModel> : IContext<TModel> where TModel : class, IDisposable
    {
        public Context()
        {
            DbContext = new AuditDb.FLoversEntities();
            DbSet = DbContext.Set<TModel>();
        }

        public Context(AuditDbContext db)
        {
            DbContext = db;
            DbSet = DbContext.Set<TModel>();
        }

        public AuditDbContext DbContext { get; set; }

        public IDbSet<TModel> DbSet { get; set; }


        public void Dispose()
        {
            DbContext.Dispose();
        }

    }

}
