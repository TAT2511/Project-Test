using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

/// <summary>
/// 1: hiện vật
/// 2: hiện kim
/// </summary>
public partial class AlumniThongTinQuyQuyenGop
{
    public Guid Id { get; set; }

    public Guid? TruongId { get; set; }

    public string? MaQuyQuyenGop { get; set; }

    public string TenQuyQuyenGop { get; set; } = null!;

    public string? TieuDe { get; set; }

    public string? MoTa { get; set; }

    public string? MoTaChiTiet { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgạyKetThuc { get; set; }

    public DateTime? NgayHuy { get; set; }

    public DateTime? NgayHetHanQuyenGop { get; set; }

    /// <summary>
    /// xác định quỹ quyên góp có bị khóa hay không
    /// 1 - locked
    /// 0 - unlocked
    /// </summary>
    public bool? KhoaQuyQuyenGop { get; set; }

    /// <summary>
    /// Xác định quỹ quyên góp publish cho người dùng cuối được phép thấy thông tin và tiến hành quyên góp
    /// 1 - công bố
    /// 0 - chưa công bố
    /// </summary>
    public bool? CongBoQuyQuyenGop { get; set; }

    /// <summary>
    /// 1 - Chưa bắt đầu, 
    /// 2 - Đang diễn ra, 
    /// 3 - Hủy, 
    /// 4 - Hết hạn quyên góp
    /// 5 - Kết thúc quỹ quyên góp
    /// </summary>
    public short? TrangThai { get; set; }

    /// <summary>
    /// Mục tiêu của quỹ quyên góp là gi , hạn mức
    /// </summary>
    public string? MucTieuQuyenGop { get; set; }

    /// <summary>
    /// trường hợp quyên góp hình thức là hiện kim, thì admin có thể setup hạn mức quyên góp. khi số tiền quyên góp đạt mức hạn mức , có thể tự động chuyển trạng thái sang &quot;Hết hạn quyên góp&quot; hoặc &quot;Ngưng tiếp nhận quyên góp&quot;
    /// </summary>
    public decimal? HanMucQuyenGop { get; set; }

    public string? DiaDiemQuyenGop { get; set; }

    public decimal? TongSoTienQuyenGop { get; set; }

    /// <summary>
    /// Lưu trữ đường dẫn của file quyết định cho quỹ quyên góp
    /// </summary>
    public string? QuyetDinhQuyQuyenGop { get; set; }

    public string? TaiKhoanNhanQuyenGop { get; set; }

    public string? TenTaiKhoanNhanQuyenGop { get; set; }

    public string? TenNganHang { get; set; }

    /// <summary>
    /// trong trường hợp người quyên góp thực hiện chuyển khoản thì bên phía nhà trường cung cấp mã QR Code để người quyên góp có thể scan nếu có nhu cầu
    /// </summary>
    public string? HinhAnhMaQrcode { get; set; }

    /// <summary>
    /// xác định hình thức quyên góp
    /// 1 - Hiện vật
    /// 2 - hiện kim
    /// </summary>
    public short? HinhThucQuyenGop { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<AlumniLichSuDongGop> AlumniLichSuDongGops { get; set; } = new List<AlumniLichSuDongGop>();

    public virtual AlumniThongTinTruong? Truong { get; set; }
}
