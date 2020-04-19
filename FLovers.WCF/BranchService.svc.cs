using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using FLovers.BL.BaseClasses;
using FLovers.BL.Logic;
using FLovers.DAL.Repository.Dtos;
using FLovers.Log.Services.Wcf;
using FLovers.Shared.RequestObjects;
using FLovers.Shared.ResponseObjects;

namespace FLovers.WCF
{
    [GlobalErrorBehavior(typeof(GlobalErrorHandler))]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]

    public class BranchService : IBranchService
    {
        public BranchLogic BranchLogic { get; set; } = new BranchLogic();

        public virtual CreateResponse<BranchDto> Create(CreateRequest<BranchDto> request)
        {
            return BranchLogic.Create(request);
        }

        public DeleteResponse<BranchDto> Delete(DeleteRequest<BranchDto> request)
        {
            return BranchLogic.Delete(request);
        }

        public UpdateResponse<BranchDto> Update(UpdateRequest<BranchDto> request)
        {
            return BranchLogic.Update(request);
        }

        public GetAllResponse<BranchDto> GetAll(GetAllRequest request)
        {
            return BranchLogic.GetAll(request);
        }

        public GetByIdResponse<BranchDto> GetById(GetByIdRequest<BranchDto> request)
        {
            return BranchLogic.GetById(request);
        }

        public SearchFirstResponse<BranchDto> SearchFirst(SearchFirstRequest<BranchDto> request)
        {
            return BranchLogic.SearchFirst(request);
        }

        public SearchForResponse<BranchDto> SearchFor(SearchForRequest<BranchDto> request)
        {
            return BranchLogic.SearchFor(request);
        }

        public GetAllPagedResponse<BranchDto> GetAllPaged(GetAllPagedRequest<BranchDto> request)
        {
            return BranchLogic.GetAllPaged(request);
        }

        public GetAllPagedAndFilteredResponse<BranchDto> GetAllPagedAndFiltered(GetAllPagedAndFilteredRequest<BranchDto> request)
        {
            return BranchLogic.GetAllPagedAndFiltered(request);
        }
    }
}
