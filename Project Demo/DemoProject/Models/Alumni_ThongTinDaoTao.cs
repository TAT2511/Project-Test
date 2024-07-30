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
    
    public partial class Alumni_ThongTinDaoTao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumni_ThongTinDaoTao()
        {
            this.Alumni_KetQuaDaoTao = new HashSet<Alumni_KetQuaDaoTao>();
            this.Alumni_QuyetDinhDaoTao = new HashSet<Alumni_QuyetDinhDaoTao>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid CuuSV_Id { get; set; }
        public string NienKhoa { get; set; }
        public string MaKhoaHoc { get; set; }
        public string TenKhoaHoc { get; set; }
        public string MaNganhHoc { get; set; }
        public string TenNganhHoc { get; set; }
        public string HinhThucDaoTao { get; set; }
        public string LopSV { get; set; }
        public string ChucVu { get; set; }
        public string DoiTuong { get; set; }
        public string THPTLop12 { get; set; }
        public string MaChuyenNganh { get; set; }
        public string TenChuyenNganh { get; set; }
        public int NamTotNghiep { get; set; }
        public string SoQuyetDinh { get; set; }
        public Nullable<System.DateTime> NgayKyQuyetDinh { get; set; }
        public string NguoiKyQuyetDinh { get; set; }
        public string ChucVuNguoiKy { get; set; }
        public string NgonNguDaoTao { get; set; }
        public string SoVaoSoGocCapBang { get; set; }
        public string SoHieuVanBang { get; set; }
        public string MaKhoaHoc_TiengAnh { get; set; }
        public string TenKhoaHoc_TiengAnh { get; set; }
        public string MaNganhHoc_TiengAnh { get; set; }
        public string TenNganhHoc_TiengAnh { get; set; }
        public string HinhThucDaoTao_TiengAnh { get; set; }
        public string HuongDaoTao { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Deleted { get; set; }
        public string DeletedBy { get; set; }
    
        public virtual Alumni_CuuSV Alumni_CuuSV { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumni_KetQuaDaoTao> Alumni_KetQuaDaoTao { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumni_QuyetDinhDaoTao> Alumni_QuyetDinhDaoTao { get; set; }
    }
}
