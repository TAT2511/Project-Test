using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

public partial class AlumniThongTinGiaoDich
{
    public Guid Id { get; set; }

    public Guid? DongGopQuyenGopId { get; set; }

    public Guid? DangKySuKienId { get; set; }

    public Guid TaiKhoanId { get; set; }

    public string? HoTenNguoiThucHien { get; set; }

    public string? EmailNguoiThucHien { get; set; }

    public string? SoDienThoaiNguoiThucHien { get; set; }

    public DateTime NgayThucHien { get; set; }

    /// <summary>
    /// Số tiền yêu cầu thực hiện
    /// </summary>
    public decimal? SoTien { get; set; }

    /// <summary>
    /// 1 - tiền mặt
    /// 2 - chuyển khoản
    /// </summary>
    public short? HinhThuc { get; set; }

    public string? MaGiaoDich { get; set; }

    /// <summary>
    /// số tiền thực tế đã thực hiện
    /// </summary>
    public decimal? SoTienGiaoDich { get; set; }

    /// <summary>
    /// Trạng thái giao dịch
    /// 1 - Mới (mới tạo thông tin)
    /// 2 - Đang xử lý
    /// 3 - Hoàn Thành
    /// 4 - Hủy ( vì lý do gi đó giao dịch bị hủy)
    /// </summary>
    public short? TrangThai { get; set; }

    /// <summary>
    /// ngày bên nhà trường xác nhận đã nhận được tiền
    /// </summary>
    public DateTime? NgayNhanKetQua { get; set; }

    public Guid? TaiKhoanNhanId { get; set; }

    public string? TenNguoiNhan { get; set; }

    public string? DonViNhan { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AlumniDangKySuKien? DangKySuKien { get; set; }

    public virtual AlumniLichSuDongGop? DongGopQuyenGop { get; set; }

    public virtual AlumniTaikhoan TaiKhoan { get; set; } = null!;

    public virtual AlumniTaikhoan? TaiKhoanNhan { get; set; }
}
