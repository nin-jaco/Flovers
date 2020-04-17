using System.Runtime.Serialization;
using FLovers.Shared.BaseClasses;

namespace FLovers.Shared.RequestObjects
{
    [DataContract]
    public class GetByIdRequest<TDto> : RequestBase where TDto : class
    {
        [DataMember]
        public object Key { get; set; }
        [DataMember]
        public RequestBase RequestBase { get; set; }


        public GetByIdRequest()
        {
            RequestBase = base.GetBase();
        }

        public GetByIdRequest(object key)
        {
            Key = key;
            RequestBase = base.GetBase();
        }

        public GetByIdRequest(object key, RequestBase requestBase)
        {
            Key = key;
            RequestBase = requestBase;
        }
    }
}
