using System.Runtime.Serialization;
using FLovers.Shared.BaseClasses;

namespace FLovers.Shared.RequestObjects
{
    [DataContract]
    public class CreateRequest<TDto> : RequestBase where TDto : new()
    {
        [DataMember]
        public TDto Item { get; set; }
        
        [DataMember]
        public RequestBase RequestBase { get; set; }

        public CreateRequest(TDto item)
        {
            Item = item;
            RequestBase = base.GetBase();
        }

        public CreateRequest(TDto item, RequestBase requestBase)
        {
            Item = item;
            RequestBase = requestBase;
        }




    }
}
