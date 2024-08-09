using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

public partial class AlumniDangKySuKien
{
    public Guid Id { get; set; }

    public Guid SuKienId { get; set; }

    public Guid TaiKhoanId { get; set; }

    public int? SoLuongDangKy { get; set; }

    public decimal? GiaVe { get; set; }

    public decimal? TongSoTienVe { get; set; }

    public DateTime? NgayDangKy { get; set; }

    /// <summary>
    /// Ghi nhận ngày hủy tham gia sự kiện
    /// </summary>
    public DateTime? NgayHuyDangKy { get; set; }

    public string? LyDoHuyDangKy { get; set; }

    /// <summary>
    /// Ngày tham gia sự kiện có thể khác ngày bắt đầu sự kiện đối với những sự kiện diễn ra trong nhiều ngày
    /// </summary>
    public DateTime? NgayThamGiaSuKien { get; set; }

    /// <summary>
    /// ghi nhận trạng thái thanh toán giá vé
    /// 1 - miễn phí
    /// 2 - chưa thanh toán
    /// 3 - thanh toán sau
    /// 4 - đã thanh toán
    /// 
    /// </summary>
    public short? TrangThaiThanhToan { get; set; }

    public DateTime? DiemDanhSuKien { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<AlumniThongTinGiaoDich> AlumniThongTinGiaoDiches { get; set; } = new List<AlumniThongTinGiaoDich>();

    public virtual AlumniThongTinSuKien SuKien { get; set; } = null!;

    public virtual AlumniTaikhoan TaiKhoan { get; set; } = null!;
}
