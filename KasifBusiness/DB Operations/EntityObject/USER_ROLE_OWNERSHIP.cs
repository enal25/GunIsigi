//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KasifBusiness.DB_Operations.EntityObject
{
    using System;
    using System.Collections.Generic;
    
    public partial class USER_ROLE_OWNERSHIP
    {
        public long GUID { get; set; }
        public short STATUS { get; set; }
        public long LAST_UPDATED { get; set; }
        public Nullable<long> ROLE_GUID { get; set; }
        public string USER_ID { get; set; }
        public Nullable<long> USER_GUID { get; set; }
    }
}
