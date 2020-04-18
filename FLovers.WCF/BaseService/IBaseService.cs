using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using FLovers.Shared.RequestObjects;
using FLovers.Shared.ResponseObjects;

namespace FLovers.WCF.BaseService
{
    [ServiceContract(Namespace = "FLovers.WCF")]
    public interface IBaseService<TDto> where TDto : class, new()
    {
        [OperationContract(Name = "Create")]
        CreateResponse<TDto> Create(CreateRequest<TDto> request);

        [OperationContract(Name = "Delete")]
        DeleteResponse<TDto> Delete(DeleteRequest<TDto> request);

        [OperationContract(Name = "Update")]
        UpdateResponse<TDto> Update(UpdateRequest<TDto> request);

        [OperationContract(Name = "GetAll")]
        GetAllResponse<TDto> GetAll(GetAllRequest request);

        [OperationContract(Name = "GetById")]
        GetByIdResponse<TDto> GetById(GetByIdRequest<TDto> request);

        [OperationContract(Name = "SearchFirst")]
        SearchFirstResponse<TDto> SearchFirst(SearchFirstRequest<TDto> request);

        [OperationContract(Name = "SearchFor")]
        SearchForResponse<TDto> SearchFor(SearchForRequest<TDto> request);

        [OperationContract(Name = "GetAllPaged")]
        GetAllPagedResponse<TDto> GetAllPaged(GetAllPagedRequest<TDto> request);

        [OperationContract(Name = "GetAllConditional")]
        GetAllPagedAndFilteredResponse<TDto> GetAllPagedAndFiltered(GetAllPagedAndFilteredRequest<TDto> request);
    }
}