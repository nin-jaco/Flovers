using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using FLovers.BL.Logic;
using FLovers.DAL.Repository.Dtos;
using FLovers.Log.Services.Wcf;
using FLovers.Shared.BaseClasses;
using FLovers.Shared.RequestObjects;
using FLovers.Shared.ResponseObjects;

namespace FLovers.WCF
{
    [GlobalErrorBehavior(typeof(GlobalErrorHandler))]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]

    public class ProductService : IProductService
    {
        public ProductLogic BranchLogic { get; set; } = new ProductLogic();

        public virtual CreateResponse<ProductDto> Create(CreateRequest<ProductDto> request)
        {
            return BranchLogic.Create(request);
        }

        public DeleteResponse<ProductDto> Delete(DeleteRequest<ProductDto> request)
        {
            return BranchLogic.Delete(request);
        }

        public UpdateResponse<ProductDto> Update(UpdateRequest<ProductDto> request)
        {
            return BranchLogic.Update(request);
        }

        public GetAllResponse<ProductDto> GetAll(GetAllRequest request)
        {
            return BranchLogic.GetAll(request);
        }

        public GetByIdResponse<ProductDto> GetById(GetByIdRequest<ProductDto> request)
        {
            return BranchLogic.GetById(request);
        }

        public SearchFirstResponse<ProductDto> SearchFirst(SearchFirstRequest<ProductDto> request)
        {
            return BranchLogic.SearchFirst(request);
        }

        public SearchForResponse<ProductDto> SearchFor(SearchForRequest<ProductDto> request)
        {
            return BranchLogic.SearchFor(request);
        }

        public GetAllPagedResponse<ProductDto> GetAllPaged(GetAllPagedRequest<ProductDto> request)
        {
            return BranchLogic.GetAllPaged(request);
        }

        public GetAllPagedAndFilteredResponse<ProductDto> GetAllPagedAndFiltered(GetAllPagedAndFilteredRequest<ProductDto> request)
        {
            return BranchLogic.GetAllPagedAndFiltered(request);
        }

        public ResponseBase AssignAProductToAStore(int branchId, int productId, RequestBase requestBase)
        {
            return BranchLogic.AssignAProductToAStore(branchId, productId, requestBase);
        }
    }
}
