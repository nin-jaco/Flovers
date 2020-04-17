using System.Runtime.Serialization;
using FLovers.Shared.BaseClasses;
using Serialize.Linq.Nodes;

namespace FLovers.Shared.RequestObjects
{
    [DataContract]
    public class SearchFirstRequest<TDto> : RequestBase where TDto : class 
    {

        [DataMember]
        public ExpressionNode Predicate { get; set; }
        [DataMember] 
        public RequestBase RequestBase { get; set; }

        public SearchFirstRequest()
        {
            RequestBase = base.GetBase();
        }

        public SearchFirstRequest(ExpressionNode predicate, RequestBase requestBase)
        {
            Predicate = predicate;
            RequestBase = requestBase;
        }

        
    }
}
