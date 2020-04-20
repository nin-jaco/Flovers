using System.Collections.Generic;
using System.ServiceModel;
using FLovers.DAL.Repository.Dtos;
using FLovers.Shared.BaseClasses;
using FLovers.WCF.BaseService;

namespace FLovers.WCF
{
    [ServiceContract(Namespace = "FLovers.WCF", Name = "ProductService", SessionMode = SessionMode.NotAllowed)]
    [ServiceKnownType(typeof(ProductDto))]
    public interface IProductService : IBaseService<ProductDto>
    {
        [OperationContract]
        ResponseBase AssignAProductToAStore(int branchId, int productId, RequestBase requestBase);

        [OperationContract]
        List<ProductDto> GetAllByStoreId(int branchId, RequestBase requestBase);
    }
}
