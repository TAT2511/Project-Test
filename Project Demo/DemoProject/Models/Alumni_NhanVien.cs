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
    
    public partial class Alumni_NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumni_NhanVien()
        {
            this.Alumni_HoSoNhanVien = new HashSet<Alumni_HoSoNhanVien>();
            this.Alumni_Taikhoan = new HashSet<Alumni_Taikhoan>();
        }
    
        public System.Guid Id { get; set; }
        public string Ho_NhanVien { get; set; }
        public string Ten_NhanVien { get; set; }
        public string HoTen_NhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public string MaTruongQuanLy { get; set; }
        public Nullable<bool> SuDung { get; set; }
        public string MaDinhDanh { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public Nullable<System.Guid> DanToc_Id { get; set; }
        public Nullable<System.Guid> TinhThanhPhoThuongTru_Id { get; set; }
        public Nullable<System.Guid> QuanHuyenThuongTru_Id { get; set; }
        public Nullable<System.Guid> XaPhuongThuongTru_Id { get; set; }
        public string DiaChiThuongTru { get; set; }
        public string TonGiao { get; set; }
        public string QueQuan { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Deleted { get; set; }
        public string DeletedBy { get; set; }
    
        public virtual Alumni_DonViHanhChinh Alumni_DonViHanhChinh { get; set; }
        public virtual Alumni_DonViHanhChinh Alumni_DonViHanhChinh1 { get; set; }
        public virtual Alumni_DonViHanhChinh Alumni_DonViHanhChinh2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumni_HoSoNhanVien> Alumni_HoSoNhanVien { get; set; }
        public virtual Alumni_QuocGia Alumni_QuocGia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumni_Taikhoan> Alumni_Taikhoan { get; set; }
    }
}