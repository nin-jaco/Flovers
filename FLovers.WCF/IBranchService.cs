using System.ServiceModel;
using FLovers.DAL.Repository.Dtos;
using FLovers.Shared.BaseClasses;
using FLovers.WCF.BaseService;

namespace FLovers.WCF
{
    [ServiceContract(Namespace = "FLovers.WCF", Name = "BranchService", SessionMode = SessionMode.NotAllowed)]
    [ServiceKnownType(typeof(BranchDto))]
    public interface IBranchService : IBaseService<BranchDto>
    {
        
    }
}
