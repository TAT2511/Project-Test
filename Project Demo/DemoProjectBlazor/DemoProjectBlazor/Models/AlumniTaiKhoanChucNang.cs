using System;
using System.Collections.Generic;

namespace DemoProject.Server.Models;

public partial class AlumniTaiKhoanChucNang
{
    public Guid Id { get; set; }

    public Guid TaiKhoanId { get; set; }

    public Guid ChucNangId { get; set; }

    public string? DeletedBy { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public virtual AlumniChucNang ChucNang { get; set; } = null!;

    public virtual AlumniTaikhoan TaiKhoan { get; set; } = null!;
}
