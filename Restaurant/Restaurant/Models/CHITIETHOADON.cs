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
    
    public partial class CHITIETHOADON
    {
        public string MA_CTHD { get; set; }
        public string MAHD { get; set; }
        public string MAMONAN { get; set; }
        public Nullable<int> SOLUONG { get; set; }
        public Nullable<decimal> THANHTIEN { get; set; }
    
        public virtual HOADON HOADON { get; set; }
        public virtual MONAN MONAN { get; set; }
    }
}