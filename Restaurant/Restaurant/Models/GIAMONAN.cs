//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GIAMONAN
    {
        public string MAGIA { get; set; }
        public string MAMONAN { get; set; }
        public Nullable<System.DateTime> NGAYCAPNHAT { get; set; }
        public Nullable<decimal> DONGIA { get; set; }
    
        public virtual MONAN MONAN { get; set; }
    }
}
