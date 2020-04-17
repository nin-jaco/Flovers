using System.Runtime.Serialization;
using FLovers.Shared.BaseClasses;

namespace FLovers.Shared.RequestObjects
{
    [DataContract]
    public class GetAllRequest : RequestBase
    {
        [DataMember]
        public RequestBase RequestBase { get; set; }

        public GetAllRequest()
        {
            RequestBase = base.GetBase();
        }

        public GetAllRequest(RequestBase requestBase)
        {
            RequestBase = requestBase;
        }

    }
}
