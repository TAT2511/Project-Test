using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

public partial class AlumniChiTietSuKien
{
    public Guid Id { get; set; }

    public Guid SuKienId { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public string TenChiTietSuKien { get; set; } = null!;

    public string? MoTa { get; set; }

    public string? MoTaChiTiet { get; set; }

    public int? SoNgayThucHien { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AlumniThongTinSuKien SuKien { get; set; } = null!;
}
