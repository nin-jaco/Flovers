//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FLovers.DAL.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomAuditEvent
    {
        public int Id { get; set; }
        public Nullable<int> IdAuditEvent { get; set; }
    
        public virtual AuditEvent AuditEvent { get; set; }
    }
}
