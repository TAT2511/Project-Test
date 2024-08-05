//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alumni_DangKySuKien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumni_DangKySuKien()
        {
            this.Alumni_ThongTinGiaoDich = new HashSet<Alumni_ThongTinGiaoDich>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid SuKien_Id { get; set; }
        public System.Guid TaiKhoan_Id { get; set; }
        public Nullable<int> SoLuongDangKy { get; set; }
        public Nullable<decimal> GiaVe { get; set; }
        public Nullable<decimal> TongSoTienVe { get; set; }
        public Nullable<System.DateTime> NgayDangKy { get; set; }
        public Nullable<System.DateTime> NgayHuyDangKy { get; set; }
        public string LyDoHuyDangKy { get; set; }
        public Nullable<System.DateTime> NgayThamGiaSuKien { get; set; }
        public Nullable<short> TrangThaiThanhToan { get; set; }
        public Nullable<System.DateTime> DiemDanhSuKien { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Deleted { get; set; }
        public string DeletedBy { get; set; }
    
        public virtual Alumni_Taikhoan Alumni_Taikhoan { get; set; }
        public virtual Alumni_ThongTinSuKien Alumni_ThongTinSuKien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumni_ThongTinGiaoDich> Alumni_ThongTinGiaoDich { get; set; }
    }
}