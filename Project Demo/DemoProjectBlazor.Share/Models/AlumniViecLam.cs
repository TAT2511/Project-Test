using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

/// <summary>
/// &quot;01&quot; - Thi tuyển
/// &quot;02&quot; - Xét tuyển
/// &quot;03&quot; - Hợp đồng
/// &quot;04&quot; - Biệt phái
/// &quot;05&quot; - Điều động
/// 
/// </summary>
public partial class AlumniViecLam
{
    public Guid Id { get; set; }

    public Guid CuuSvId { get; set; }

    /// <summary>
    /// Thực tập
    /// Bán thời gian
    /// Toàn thời gian
    /// </summary>
    public string? HinhThucTuyenDung { get; set; }

    public string? MoTaViecLam { get; set; }

    public string? TenCongTy { get; set; }

    public string? ViTriViecLam { get; set; }

    public string? ThoiGianLamViec { get; set; }

    /// <summary>
    /// mô tả kinh nghiệm làm việc
    /// </summary>
    public string? KinhNghiemLamViec { get; set; }

    public bool? DangCoViecLam { get; set; }

    public decimal? MucLuongKhoiDiem { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AlumniCuuSv CuuSv { get; set; } = null!;
}
