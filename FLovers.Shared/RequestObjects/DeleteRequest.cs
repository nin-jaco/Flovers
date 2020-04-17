using System.Runtime.Serialization;
using FLovers.Shared.BaseClasses;

namespace FLovers.Shared.RequestObjects
{
    [DataContract]
    public class DeleteRequest<TDto> : RequestBase
    {
        [DataMember] public TDto Item { get; set; }
        [DataMember] public RequestBase RequestBase { get; set; }

        public DeleteRequest()
        {
            RequestBase = base.GetBase();
        }

        public DeleteRequest(TDto item, RequestBase requestBase)
        {
            Item = item;
            RequestBase = requestBase;
        }

        
    }
}
