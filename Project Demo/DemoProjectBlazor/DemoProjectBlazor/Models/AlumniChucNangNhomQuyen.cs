using System;
using System.Collections.Generic;

namespace DemoProject.Server.Models;

public partial class AlumniChucNangNhomQuyen
{
    public Guid Id { get; set; }

    public Guid ChucNangId { get; set; }

    public Guid NhomQuyenId { get; set; }

    public bool? SuDung { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AlumniChucNang ChucNang { get; set; } = null!;

    public virtual AlumniNhomQuyen NhomQuyen { get; set; } = null!;
}
