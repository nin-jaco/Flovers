using System.Linq;
using FLovers.Shared.BaseClasses;
using FLovers.Shared.RequestObjects;

namespace FLovers.DAL.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        TEntity Add(CreateRequest<TEntity> request);
        TEntity Remove(DeleteRequest<TEntity> request);
        TEntity Update(UpdateRequest<TEntity> request);
        IQueryable<TEntity> GetAll(GetAllRequest request);
        TEntity Get(GetByIdRequest<TEntity> request);
        TEntity SearchFirst(SearchFirstRequest<TEntity> request);
        IQueryable<TEntity> SearchFor(SearchForRequest<TEntity> request);
        void SaveChanges(RequestBase requestBase);
    }
}
