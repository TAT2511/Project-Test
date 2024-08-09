using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

public partial class AlumniThongTinSuKien
{
    public Guid Id { get; set; }

    public Guid TruongId { get; set; }

    public Guid? KhoaId { get; set; }

    public string? TenKhoa { get; set; }

    public string MaSuKien { get; set; } = null!;

    public string TenSuKien { get; set; } = null!;

    public string? TieuDe { get; set; }

    public string? MoTa { get; set; }

    public string? MoTaChiTiet { get; set; }

    public DateTime NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public string? DiaDiemToChuc { get; set; }

    public int? SoLuong { get; set; }

    public int? SoLuongDangKy { get; set; }

    public DateTime? NgayHuySuKien { get; set; }

    public DateTime? NgayBatDauDangKy { get; set; }

    public DateTime? NgayKetThucDangKy { get; set; }

    /// <summary>
    /// Xác định sự kiện publish cho người dùng đăng ký sự kiện hay chưa
    /// 1: published
    /// 0: unpublished
    /// </summary>
    public bool? CongBoSuKien { get; set; }

    public string? LyDoHuySuKien { get; set; }

    /// <summary>
    /// 1 - Chưa diễn ra (sự kiện chưa đến ngày diễn ra),
    /// 2 -  Đang diễn ra (sự kiện đang trong thời gian diễn ra), 
    /// 3 - Hủy (sự kiện bị hủy),
    /// 4 - Hết hạn đăng ký (sự kiện hết thời hạn đăng ký)
    /// </summary>
    public short? TrangThai { get; set; }

    /// <summary>
    /// Ghi nhận hình thức loại vé của sự kiện là loại gi
    /// 1 - Vé tặng
    /// 2 - Mua vé
    /// </summary>
    public short? HinhThucBanVe { get; set; }

    public decimal? GiaVe { get; set; }

    public int? SoNgaySuKien { get; set; }

    public string? HinhAnhSuKien { get; set; }

    public string? NhomChuoiSuKien { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<AlumniChiTietSuKien> AlumniChiTietSuKiens { get; set; } = new List<AlumniChiTietSuKien>();

    public virtual ICollection<AlumniDangKySuKien> AlumniDangKySuKiens { get; set; } = new List<AlumniDangKySuKien>();

    public virtual ICollection<AlumniDanhGiaSuKien> AlumniDanhGiaSuKiens { get; set; } = new List<AlumniDanhGiaSuKien>();

    public virtual AlumniThongTinKhoa? Khoa { get; set; }

    public virtual AlumniThongTinTruong Truong { get; set; } = null!;
}
