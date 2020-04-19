using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FLovers.DAL.Repository.Dtos;
using FLovers.WCF.BaseService;

namespace FLovers.WCF
{
    [ServiceContract(Namespace = "FLovers.WCF", Name = "IBranchService", SessionMode = SessionMode.NotAllowed)]
    [ServiceKnownType(typeof(BranchDto))]
    public interface IBranchService : IBaseService<BranchDto>
    {
        
    }
}
