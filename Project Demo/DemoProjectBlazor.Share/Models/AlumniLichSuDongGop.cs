using System;
using System.Collections.Generic;

namespace DemoProject.Server.Models;

public partial class AlumniLichSuDongGop
{
    public Guid Id { get; set; }

    public Guid? QuyQuyenGopId { get; set; }

    public Guid? TaiKhoanId { get; set; }

    public decimal? SoTienDongGop { get; set; }

    public string? HienVatDongGop { get; set; }

    public DateTime? NgayDongGop { get; set; }

    public string? DiaDiemDongGop { get; set; }

    public string? GhiChu { get; set; }

    public string? NguoiNhanDongGop { get; set; }

    public Guid? TaiKhoanNhanDongGopId { get; set; }

    public string? DonViNhanDongGop { get; set; }

    /// <summary>
    /// trong trường hợp nhận hiện vật có thể cần chụp hình để ghi nhận làm bằng chứng
    /// </summary>
    public string? HinhAnhDinhKem { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<AlumniThongTinGiaoDich> AlumniThongTinGiaoDiches { get; set; } = new List<AlumniThongTinGiaoDich>();

    public virtual AlumniThongTinQuyQuyenGop? QuyQuyenGop { get; set; }

    public virtual AlumniTaikhoan? TaiKhoan { get; set; }
}
