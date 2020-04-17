using System.Runtime.Serialization;
using FLovers.Shared.BaseClasses;
using Serialize.Linq.Nodes;

namespace FLovers.Shared.RequestObjects
{
    [DataContract]
    public class SearchForRequest<TDto> : RequestBase
    {
        [DataMember]
        public ExpressionNode Predicate { get; set; }
        [DataMember] public RequestBase RequestBase { get; set; }

        public SearchForRequest()
        {
            RequestBase = base.GetBase();
        }

        public SearchForRequest(ExpressionNode predicate, RequestBase requestBase)
        {
            Predicate = predicate;
            RequestBase = requestBase;
        }
    }
}
