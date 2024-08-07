using System;
using System.Collections.Generic;

namespace DemoProject.Server.Models;

/// <summary>
/// Danh mục từ điển, dùng để quản lý danh sách quốc gia trong hệ thống.
/// </summary>
public partial class AlumniQuocGium
{
    public Guid Id { get; set; }

    public string MaQuocGia { get; set; } = null!;

    public string TenQuocGia { get; set; } = null!;

    public string? MoTa { get; set; }

    public bool ConSuDung { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<AlumniCuuSv> AlumniCuuSvs { get; set; } = new List<AlumniCuuSv>();

    public virtual ICollection<AlumniDonViHanhChinh> AlumniDonViHanhChinhs { get; set; } = new List<AlumniDonViHanhChinh>();

    public virtual ICollection<AlumniNhanVien> AlumniNhanViens { get; set; } = new List<AlumniNhanVien>();
}
