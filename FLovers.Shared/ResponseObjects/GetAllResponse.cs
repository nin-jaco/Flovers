using System.Collections.Generic;
using System.Runtime.Serialization;
using FLovers.Shared.BaseClasses;

namespace FLovers.Shared.ResponseObjects
{
    [DataContract]
    public class GetAllResponse<TDto> : ResponseBase
    {
        [DataMember] 
        public List<TDto> ItemList { get; set; }
    }
}
