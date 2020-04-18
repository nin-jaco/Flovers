using System;
using System.Runtime.Serialization;

namespace FLovers.Shared.BaseClasses
{
    [Serializable]
    [DataContract(IsReference = true, Namespace = "FLovers.Shared.BaseClasses", Name = "RequestBase")]
    [KnownType(typeof(RequestBase))]
    public class RequestBase
    {
        [DataMember] 
        public string SenderComputerIp { get; set; }
        [DataMember] 
        public string SentFromUrl { get; set; }
        [DataMember] 
        public string UserAgent { get; set; }
        [DataMember] 
        public string Browser { get; set; }
        [DataMember] 
        public string BrowserVersion { get; set; }

        [DataMember] 
        public int? IdUser { get; set; }
        [DataMember] 
        public string Username { get; set; }
        [DataMember]
        public int? IdBranch { get; set; }
        [DataMember] 
        public string BranchName { get; set; }

        [DataMember] 
        public string Protocol { get; set; }
        [DataMember] 
        public string Host { get; set; }
        [DataMember] 
        public string Port { get; set; }
        [DataMember] 
        public string Ip { get; set; }

        public RequestBase()
        {
        }

        public RequestBase GetBase()
        {
            return (RequestBase) this;
        }
    }
}
