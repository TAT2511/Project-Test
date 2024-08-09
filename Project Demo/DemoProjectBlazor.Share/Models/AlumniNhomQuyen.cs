using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

public partial class AlumniNhomQuyen
{
    public Guid Id { get; set; }

    public byte[] MaNhomQuyen { get; set; } = null!;

    public string TenNhomQuyen { get; set; } = null!;

    public string? MoTa { get; set; }

    /// <summary>
    /// 1: hiển thị
    /// 0: không hiển thị
    /// 
    /// </summary>
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

    public virtual ICollection<AlumniTaiKhoanNhomQuyen> AlumniTaiKhoanNhomQuyens { get; set; } = new List<AlumniTaiKhoanNhomQuyen>();

    public virtual AlumniThongTinTruong Truong { get; set; } = null!;
}
