using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FLovers.DAL.Repository.Dtos;
using FLovers.DAL.Repository.Entities;
using FLovers.WCF.BaseService;

namespace FLovers.WCF
{
    [ServiceContract(Namespace = "FLovers.WCF", Name = "ProductService", SessionMode = SessionMode.NotAllowed)]
    [ServiceKnownType(typeof(ProductDto))]
    public interface IProductService : IBaseService<ProductDto>
    {
        
    }
}
