using FLovers.Shared.RequestObjects;
using FLovers.Shared.ResponseObjects;

namespace FLovers.BL.Interfaces
{
    public interface ILogicBase<TDto, TEntity> where TDto : class, new() where TEntity : class, new()
    {

        CreateResponse<TDto> Create(CreateRequest<TDto> request);

        DeleteResponse<TDto> Delete(DeleteRequest<TDto> request);

        UpdateResponse<TDto> Update(UpdateRequest<TDto> request);

        GetAllResponse<TDto> GetAll(GetAllRequest request);

        GetByIdResponse<TDto> GetById(GetByIdRequest<TDto> request);

        SearchFirstResponse<TDto> SearchFirst(SearchFirstRequest<TDto> request);

        SearchForResponse<TDto> SearchFor(SearchForRequest<TDto> request);

        TEntity MapToModel(TDto dto);
        TDto MapToDto(TEntity model);
    }
}
