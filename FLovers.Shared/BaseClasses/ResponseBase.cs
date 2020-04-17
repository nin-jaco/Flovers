using System.Runtime.Serialization;

namespace FLovers.Shared.BaseClasses
{
    [DataContract(Namespace = "FLovers.Shared.BaseClasses", Name = "ResponseBase")]
    [KnownType(typeof(ResponseBase))]
    public class ResponseBase
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string SuccessMessage { get; set; }

        [DataMember]
        public int? ErrorCode { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

    }
}
