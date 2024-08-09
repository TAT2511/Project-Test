using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

public partial class AlumniTaiKhoanNhomQuyen
{
    public Guid Id { get; set; }

    public Guid? TaiKhoanId { get; set; }

    public Guid? NhomQuyenId { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public bool? SuDung { get; set; }

    public virtual AlumniNhomQuyen? NhomQuyen { get; set; }

    public virtual AlumniTaikhoan? TaiKhoan { get; set; }
}
