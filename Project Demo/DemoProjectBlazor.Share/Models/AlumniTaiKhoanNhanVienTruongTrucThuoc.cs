using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

/// <summary>
/// quản lý quyền truy cập của tài khoản vào các trường trưc thuộc
/// table này dùng để kiểm tra quyền truy cập nhanh từ màn hình đăng nhập (trường hợp nhiều trường dùng chung 1 DB)
/// </summary>
public partial class AlumniTaiKhoanNhanVienTruongTrucThuoc
{
    public Guid TaiKhoanId { get; set; }

    public Guid TruongId { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    /// <summary>
    /// xác định tài khoản có bị khóa hay không ở cấp độ trường trực thuộc
    /// 1: Bị khóa
    /// 0: không bị khóa
    /// </summary>
    public bool? KhoaTaiKhoan { get; set; }

    public virtual AlumniTaikhoan TaiKhoan { get; set; } = null!;

    public virtual AlumniThongTinTruong Truong { get; set; } = null!;
}
