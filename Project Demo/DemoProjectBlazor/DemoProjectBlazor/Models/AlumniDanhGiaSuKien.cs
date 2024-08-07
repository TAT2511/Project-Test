using System;
using System.Collections.Generic;

namespace DemoProject.Server.Models;

public partial class AlumniDanhGiaSuKien
{
    public Guid Id { get; set; }

    public Guid? SuKienId { get; set; }

    public Guid? TaiKhoanId { get; set; }

    public DateTime? NgayDanhGia { get; set; }

    public string? NoiDungDanhGia { get; set; }

    /// <summary>
    /// Rating:  thang điểm từ 1 - 5
    /// </summary>
    public short? DiemDanhGia { get; set; }

    public string? TenNguoiDanhGia { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AlumniThongTinSuKien? SuKien { get; set; }

    public virtual AlumniTaikhoan? TaiKhoan { get; set; }
}
