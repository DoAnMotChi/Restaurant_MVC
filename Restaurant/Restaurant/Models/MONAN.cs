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
    
    public partial class MONAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MONAN()
        {
            this.CHITIETHOADONs = new HashSet<CHITIETHOADON>();
            this.CHITIETKHUYENMAIs = new HashSet<CHITIETKHUYENMAI>();
            this.CONGTHUCMONANs = new HashSet<CONGTHUCMONAN>();
            this.GIAMONANs = new HashSet<GIAMONAN>();
        }
    
        public string MAMONAN { get; set; }
        public string MANHOM { get; set; }
        public string MOTA { get; set; }
        public string HINHANH { get; set; }
        public string TENMONAN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETKHUYENMAI> CHITIETKHUYENMAIs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONGTHUCMONAN> CONGTHUCMONANs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIAMONAN> GIAMONANs { get; set; }
        public virtual NHOMMONAN NHOMMONAN { get; set; }
    }
}
