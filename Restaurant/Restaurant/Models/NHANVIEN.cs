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
    
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            this.HOADONs = new HashSet<HOADON>();
            this.PHIEUNHAPs = new HashSet<PHIEUNHAP>();
            this.QUANLYNHOMNGUOIDUNGs = new HashSet<QUANLYNHOMNGUOIDUNG>();
        }
    
        public string MANHANVIEN { get; set; }
        public string HOTENNHANVIEN { get; set; }
        public string GIOITINH { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public string DIACHI { get; set; }
        public string NGUYENQUAN { get; set; }
        public Nullable<System.DateTime> NGAYVAOLAM { get; set; }
        public Nullable<System.DateTime> NGAYNGHIVIEC { get; set; }
        public Nullable<decimal> SDT { get; set; }
        public string MATKHAU { get; set; }
        public string EMAIL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAP> PHIEUNHAPs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUANLYNHOMNGUOIDUNG> QUANLYNHOMNGUOIDUNGs { get; set; }
    }
}
