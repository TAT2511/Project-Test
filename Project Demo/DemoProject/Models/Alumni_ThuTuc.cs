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
    
    public partial class Alumni_ThuTuc
    {
        public System.Guid ID { get; set; }
        public string MaThuTuc { get; set; }
        public System.Guid CuuSV_Id { get; set; }
        public string TenThuTuc { get; set; }
        public Nullable<System.DateTime> NgayYeuCau { get; set; }
        public string MaLinhVuc { get; set; }
        public string TenLinhVuc { get; set; }
        public string MaLoaiHoSo { get; set; }
        public Nullable<short> TrangThai { get; set; }
        public string DonViNhanYeuCau { get; set; }
        public Nullable<System.DateTime> NgayNhanKetQua { get; set; }
        public string NguoiTraKetQua { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Deleted { get; set; }
        public string DeletedBy { get; set; }
    
        public virtual Alumni_CuuSV Alumni_CuuSV { get; set; }
    }
}
