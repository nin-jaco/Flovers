using System.Collections.Generic;
using System.Runtime.Serialization;
using FLovers.Shared.BaseClasses;

namespace FLovers.Shared.ResponseObjects
{
    [DataContract]
    public class GetAllPagedAndFilteredResponse<TDto> : ResponseBase where TDto : class, new()
    {
        [DataMember] 
        public List<TDto> ItemList { get; set; }
    }
}
