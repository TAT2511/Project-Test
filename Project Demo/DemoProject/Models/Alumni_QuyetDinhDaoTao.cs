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
    
    public partial class Alumni_QuyetDinhDaoTao
    {
        public System.Guid Id { get; set; }
        public System.Guid CuuSV_Id { get; set; }
        public Nullable<System.Guid> ThongTinDaoTao_Id { get; set; }
        public string NamHoc { get; set; }
        public string HocKy { get; set; }
        public string SoQuyetDinh { get; set; }
        public string LoaiQuyetDinh { get; set; }
        public string NoiDung { get; set; }
        public string NguoiKy { get; set; }
        public Nullable<System.DateTime> NgayKy { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Deleted { get; set; }
        public string DeletedBy { get; set; }
    
        public virtual Alumni_CuuSV Alumni_CuuSV { get; set; }
        public virtual Alumni_ThongTinDaoTao Alumni_ThongTinDaoTao { get; set; }
    }
}