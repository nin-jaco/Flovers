using System.Runtime.Serialization;
using FLovers.Shared.BaseClasses;

namespace FLovers.Shared.RequestObjects
{
    [DataContract]
    public class GetAllPagedAndFilteredRequest<TDto> : RequestBase where TDto : class, new()
    {
        [DataMember] 
        public string WhereClause { get; set; }
        [DataMember] 
        public string OrderBy { get; set; }
        [DataMember] 
        public int PageSize { get; set; }
        [DataMember] 
        public int CurrentPageIndex { get; set; }
        [DataMember] 
        public int TotalRecords { get; }

        [DataMember] 
        public RequestBase RequestBase { get; set; }

        public GetAllPagedAndFilteredRequest()
        {
            RequestBase = base.GetBase();
        }
        public GetAllPagedAndFilteredRequest(string whereClause, string orderBy, int pageSize, int currentPageIndex,
            ref int totalRecords)
        {
            WhereClause = whereClause;
            OrderBy = orderBy;
            TotalRecords = totalRecords;
            PageSize = pageSize;
            CurrentPageIndex = currentPageIndex;
            RequestBase = base.GetBase();
        }
    }
}
