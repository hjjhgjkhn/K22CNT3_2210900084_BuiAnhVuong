//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace K22CNT3_2210900084_project02.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GIO_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIO_HANG()
        {
            this.CHI_TIET_GH = new HashSet<CHI_TIET_GH>();
        }
    
        public int Ma_GH { get; set; }
        public Nullable<int> Ma_KH { get; set; }
        public System.DateTime Ngay_tao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_GH> CHI_TIET_GH { get; set; }
        public virtual KHACH_HANG KHACH_HANG { get; set; }
    }
}
