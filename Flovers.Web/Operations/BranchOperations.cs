using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FLovers.DAL.Repository.Dtos;
using FLovers.Shared.RequestObjects;
using FLovers.Shared.ResponseObjects;
using FLovers.WCF;
using FLovers.WCF.Utilities;

namespace Flovers.Web.Operations
{
    public static class BranchOperations
    {
        private static WcfProxy Proxy { get; } = new WcfProxy();

        public static GetAllResponse<BranchDto> GetAll()
        {
            return Proxy.PerformRemote<IBranchService, GetAllResponse<BranchDto>>(x =>
                x.GetAll(new GetAllRequest(UserOperations.GetRequestBaseFromSession())));
        }

        public static CreateResponse<BranchDto> Create(BranchDto branch)
        {
            return Proxy.PerformRemote<IBranchService, CreateResponse<BranchDto>>(x =>
                x.Create(new CreateRequest<BranchDto>(branch, UserOperations.GetRequestBaseFromSession())));
        }

        public static UpdateResponse<BranchDto> Update(BranchDto branch)
        {
            return Proxy.PerformRemote<IBranchService, UpdateResponse<BranchDto>>(x =>
                x.Update(new UpdateRequest<BranchDto>(branch.Id, branch, UserOperations.GetRequestBaseFromSession())));
        }

        public static DeleteResponse<BranchDto> Delete(BranchDto branch)
        {
            return Proxy.PerformRemote<IBranchService, DeleteResponse<BranchDto>>(x =>
                x.Delete(new DeleteRequest<BranchDto>(branch, UserOperations.GetRequestBaseFromSession())));
        }

        public static GetByIdResponse<BranchDto> GetById(int id)
        {
            return Proxy.PerformRemote<IBranchService, GetByIdResponse<BranchDto>>(x =>
                x.GetById(new GetByIdRequest<BranchDto>(id, UserOperations.GetRequestBaseFromSession())));
        }
    }
}