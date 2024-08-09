using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

public partial class AlumniChucNang
{
    public Guid Id { get; set; }

    public string MaChucNang { get; set; } = null!;

    public string? TenChucNang { get; set; }

    public bool? HienThi { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public Guid TruongId { get; set; }

    public virtual ICollection<AlumniChucNangNhomQuyen> AlumniChucNangNhomQuyens { get; set; } = new List<AlumniChucNangNhomQuyen>();

    public virtual ICollection<AlumniTaiKhoanChucNang> AlumniTaiKhoanChucNangs { get; set; } = new List<AlumniTaiKhoanChucNang>();

    public virtual AlumniThongTinTruong Truong { get; set; } = null!;
}
