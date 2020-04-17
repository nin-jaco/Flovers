using System.Runtime.Serialization;
using FLovers.Shared.BaseClasses;

namespace FLovers.Shared.ResponseObjects
{
    [DataContract]
    public class CreateResponse<TDto> : ResponseBase  where TDto : class, new()
    {
        [DataMember] 
        public TDto Item { get; set; }

    }
}
