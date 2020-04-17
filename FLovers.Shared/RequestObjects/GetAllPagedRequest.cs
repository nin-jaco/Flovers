using System.Runtime.Serialization;
using FLovers.Shared.BaseClasses;

namespace FLovers.Shared.RequestObjects
{
    [DataContract]
    public class GetAllPagedRequest<TDto> : RequestBase
    {
        [DataMember] 
        public int PageSize { get; set; }
        [DataMember] 
        public int CurrentPageIndex { get; set; }
        [DataMember] 
        public int TotalRecords { get; }
       
        [DataMember] 
        public RequestBase RequestBase { get; set; }

        public GetAllPagedRequest()
        {
            RequestBase = base.GetBase();
        }
        public GetAllPagedRequest(int pageSize, int currentPageIndex, ref int totalRecords)
        {
            TotalRecords = totalRecords;
            PageSize = pageSize;
            CurrentPageIndex = currentPageIndex;
            RequestBase = base.GetBase();
        }

        
    }
}
