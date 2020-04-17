using System.Runtime.Serialization;
using FLovers.Shared.BaseClasses;

namespace FLovers.Shared.RequestObjects
{
    [DataContract]
    public class UpdateRequest<TDto> : RequestBase where TDto : class
    {
        [DataMember] 
        public object Key { get; set; }
        [DataMember] 
        public TDto Item { get; set; }
        [DataMember] 
        public RequestBase RequestBase { get; set; }

        
        public UpdateRequest(object key, TDto item)
        {
            Key = key;
            Item = item;
            RequestBase = base.GetBase(); 
        }

        public UpdateRequest(object key, TDto item, RequestBase requestBase)
        {
            Key = key;
            Item = item;
            RequestBase = requestBase;
        }
    }
}
