using System;
using System.Collections.Generic;

namespace DemoProject.Server.Models;

/// <summary>
/// quản lý thông tin hồ sơ của giảng viên / nhân viên tại 1 trường cụ thể
/// </summary>
public partial class AlumniHoSoNhanVien
{
    public Guid Id { get; set; }

    public Guid? NhanVienId { get; set; }

    /// <summary>
    /// vị trí công tác của nhân viên tại trường đại học
    /// </summary>
    public string? ViTri { get; set; }

    public string? Email { get; set; }

    public string? DienThoaiLienHe { get; set; }

    /// <summary>
    /// các hình thức hợp đồng:
    /// - Viên chức HĐLV không xác định thời hạn
    /// - Viên chức HĐLV xác định thời hạn -&gt; 1 năm , 2 năm....
    /// </summary>
    public string? HinhThucHopDong { get; set; }

    public DateTime? NgayTuyenDung { get; set; }

    public Guid TruongTrucThuocId { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AlumniNhanVien? NhanVien { get; set; }

    public virtual AlumniThongTinTruong TruongTrucThuoc { get; set; } = null!;
}
