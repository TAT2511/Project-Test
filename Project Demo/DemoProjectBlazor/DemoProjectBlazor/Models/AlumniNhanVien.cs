using System;
using System.Collections.Generic;

namespace DemoProject.Server.Models;

/// <summary>
/// quản lý thông tin của giảng viên / nhân viên ở cấp cao nhất.
/// thông tin này là duy nhất đối với 1 người giảng viên / nhân viên
/// </summary>
public partial class AlumniNhanVien
{
    public Guid Id { get; set; }

    public string HoNhanVien { get; set; } = null!;

    public string TenNhanVien { get; set; } = null!;

    public string? HoTenNhanVien { get; set; }

    public string? SoDienThoai { get; set; }

    /// <summary>
    /// mã của trường cấp cao nhất
    /// </summary>
    public string MaTruongQuanLy { get; set; } = null!;

    public bool? SuDung { get; set; }

    /// <summary>
    /// có thể là CMND, CCCD hoặc hộ chiếu
    /// </summary>
    public string MaDinhDanh { get; set; } = null!;

    /// <summary>
    /// F: feamle - nữ
    /// M: male - nam
    /// </summary>
    public string? GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? NoiSinh { get; set; }

    public Guid? DanTocId { get; set; }

    public Guid? TinhThanhPhoThuongTruId { get; set; }

    public Guid? QuanHuyenThuongTruId { get; set; }

    public Guid? XaPhuongThuongTruId { get; set; }

    public string? DiaChiThuongTru { get; set; }

    public string? TonGiao { get; set; }

    public string? QueQuan { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<AlumniHoSoNhanVien> AlumniHoSoNhanViens { get; set; } = new List<AlumniHoSoNhanVien>();

    public virtual ICollection<AlumniTaikhoan> AlumniTaikhoans { get; set; } = new List<AlumniTaikhoan>();

    public virtual AlumniQuocGium? DanToc { get; set; }

    public virtual AlumniDonViHanhChinh? QuanHuyenThuongTru { get; set; }

    public virtual AlumniDonViHanhChinh? TinhThanhPhoThuongTru { get; set; }

    public virtual AlumniDonViHanhChinh? XaPhuongThuongTru { get; set; }
}
