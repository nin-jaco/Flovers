using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FLovers.DAL.Repository.Dtos;
using FLovers.Shared.BaseClasses;
using FLovers.Shared.RequestObjects;
using FLovers.Shared.ResponseObjects;
using FLovers.WCF;
using FLovers.WCF.Utilities;

namespace Flovers.Web.Operations
{
    public static class ProductOperations
    {
        private static WcfProxy Proxy { get; } = new WcfProxy();

        public static GetAllResponse<ProductDto> GetAll()
        {
            return Proxy.PerformRemote<IProductService, GetAllResponse<ProductDto>>(x =>
                x.GetAll(new GetAllRequest(UserOperations.GetRequestBaseFromSession())));
        }

        public static CreateResponse<ProductDto> Create(ProductDto product)
        {
            return Proxy.PerformRemote<IProductService, CreateResponse<ProductDto>>(x =>
                x.Create(new CreateRequest<ProductDto>(product, UserOperations.GetRequestBaseFromSession())));
        }

        public static UpdateResponse<ProductDto> Update(ProductDto product)
        {
            return Proxy.PerformRemote<IProductService, UpdateResponse<ProductDto>>(x =>
                x.Update(new UpdateRequest<ProductDto>(product.Id, product, UserOperations.GetRequestBaseFromSession())));
        }

        public static DeleteResponse<ProductDto> Delete(ProductDto product)
        {
            return Proxy.PerformRemote<IProductService, DeleteResponse<ProductDto>>(x =>
                x.Delete(new DeleteRequest<ProductDto>(product, UserOperations.GetRequestBaseFromSession())));
        }

        public static GetByIdResponse<ProductDto> GetById(int id)
        {
            return Proxy.PerformRemote<IProductService, GetByIdResponse<ProductDto>>(x =>
                x.GetById(new GetByIdRequest<ProductDto>(id, UserOperations.GetRequestBaseFromSession())));
        }

        public static ResponseBase AssignAProductToAStore(int branchId, int productId)
        {
            return Proxy.PerformRemote<IProductService, ResponseBase>(x =>
                x.AssignAProductToAStore(branchId, productId, UserOperations.GetRequestBaseFromSession()));
        }
    }
}