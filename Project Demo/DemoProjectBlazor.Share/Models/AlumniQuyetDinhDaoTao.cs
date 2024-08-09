using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

public partial class AlumniQuyetDinhDaoTao
{
    public Guid Id { get; set; }

    public Guid CuuSvId { get; set; }

    public Guid? ThongTinDaoTaoId { get; set; }

    public string? NamHoc { get; set; }

    public string? HocKy { get; set; }

    public string? SoQuyetDinh { get; set; }

    public string? LoaiQuyetDinh { get; set; }

    public string? NoiDung { get; set; }

    public string? NguoiKy { get; set; }

    public DateTime? NgayKy { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AlumniCuuSv CuuSv { get; set; } = null!;

    public virtual AlumniThongTinDaoTao? ThongTinDaoTao { get; set; }
}
