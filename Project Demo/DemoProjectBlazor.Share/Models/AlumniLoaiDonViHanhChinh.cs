using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

/// <summary>
/// Quản lý danh sách các loại đơn vị hành chính: tỉnh, thành, phố, quận, huyện, xã, phường
/// </summary>
public partial class AlumniLoaiDonViHanhChinh
{
    public Guid Id { get; set; }

    public string MaLoaiDonViHanhChinh { get; set; } = null!;

    public string TenLoaiDonViHanhChinh { get; set; } = null!;

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<AlumniDonViHanhChinh> AlumniDonViHanhChinhs { get; set; } = new List<AlumniDonViHanhChinh>();
}
