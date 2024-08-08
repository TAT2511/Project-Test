using System;
using System.Collections.Generic;

namespace DemoProject.Server.Models;

public partial class AlumniKetQuaDaoTaoChiTiet
{
    public Guid Id { get; set; }

    public Guid KetQuaDaoTaoId { get; set; }

    public string MaMonHoc { get; set; } = null!;

    public string TenMonHoc { get; set; } = null!;

    public decimal? SoTc { get; set; }

    public decimal? DiemHe10 { get; set; }

    public decimal? DiemHe4 { get; set; }

    public string? DiemChu { get; set; }

    public string? KetQua { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AlumniKetQuaDaoTao KetQuaDaoTao { get; set; } = null!;
}
