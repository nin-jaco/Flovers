using System;
using System.Data.Entity;
using Audit.EntityFramework;

namespace FLovers.DAL.Repository.Interfaces
{
    public interface IContext<TEntity> : IDisposable where TEntity : class
    {
        AuditDbContext DbContext { get; set; }
        IDbSet<TEntity> DbSet { get; set; }
    }

}
