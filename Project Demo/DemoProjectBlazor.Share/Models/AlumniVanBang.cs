using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

public partial class AlumniVanBang
{
    public Guid Id { get; set; }

    public Guid CuuSvId { get; set; }

    public Guid ThongTinDaoTaoId { get; set; }

    public string TenVanBang { get; set; } = null!;

    public DateTime? NgayNhanVanBang { get; set; }

    public string? NguoiThucHien { get; set; }

    public short? TrangThai { get; set; }

    public DateOnly? NgayCapVanBang { get; set; }

    public string? NguoiCapVanBang { get; set; }

    public string? NoiCapVanBang { get; set; }

    public string? QuyetDinh { get; set; }

    public string? SoChungChi { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AlumniThongTinDaoTao ThongTinDaoTao { get; set; } = null!;
}
