using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FLovers.BL.Interfaces
{
    public interface ICrud<TDto, TModel>
    {
        TDto Create(TDto item);
        TDto Delete(TDto item);
        TDto Update(TDto item);
        IQueryable<TDto> GetAll();
        TDto GetById(int id);
        TDto SearchFirst(Expression<Func<TModel, bool>> predicate);
        List<TDto> SearchFor(Expression<Func<TModel, bool>> predicate);
        TModel MapDtoToModel(TDto dto);
        TDto MapModelToDto(TModel model);
    }
}
