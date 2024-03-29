﻿using System.Runtime.Serialization;
using FLovers.Shared.BaseClasses;

namespace FLovers.Shared.ResponseObjects
{
    [DataContract]
    public class GetByIdResponse<TDto> : ResponseBase where TDto : class, new()
    {
        [DataMember] 
        public TDto Item { get; set; }
    }
}
