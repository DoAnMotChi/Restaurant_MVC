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
    
    public partial class CUNGUNGNGUYENLIEU
    {
        public string MANHACUNGCAP { get; set; }
        public string MANGUYENLIEU { get; set; }
        public Nullable<System.DateTime> THOIGIAN { get; set; }
    
        public virtual NGUYENLIEU NGUYENLIEU { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}