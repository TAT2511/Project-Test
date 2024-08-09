using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

/// <summary>
/// Các đơn vị hành chính thuộc về 1 đơn vị hành chính khác thì sẽ có giá trị đơn vị hành chính cha (VD: tỉnh thành phố -&gt; quận huyện, quận huyện -&gt; xã phường)
/// </summary>
public partial class AlumniDonViHanhChinh
{
    public Guid Id { get; set; }

    public string MaDonViHanhChinh { get; set; } = null!;

    public string TenDonViHanhChinh { get; set; } = null!;

    public Guid LoaiDonViHanhChinhId { get; set; }

    public Guid? DonViHanhChinhChaId { get; set; }

    public Guid? QuocGiaId { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<AlumniCuuSv> AlumniCuuSvQuanHuyens { get; set; } = new List<AlumniCuuSv>();

    public virtual ICollection<AlumniCuuSv> AlumniCuuSvTinhThanhs { get; set; } = new List<AlumniCuuSv>();

    public virtual ICollection<AlumniCuuSv> AlumniCuuSvXaPhuongs { get; set; } = new List<AlumniCuuSv>();

    public virtual ICollection<AlumniNhanVien> AlumniNhanVienQuanHuyenThuongTrus { get; set; } = new List<AlumniNhanVien>();

    public virtual ICollection<AlumniNhanVien> AlumniNhanVienTinhThanhPhoThuongTrus { get; set; } = new List<AlumniNhanVien>();

    public virtual ICollection<AlumniNhanVien> AlumniNhanVienXaPhuongThuongTrus { get; set; } = new List<AlumniNhanVien>();

    public virtual AlumniDonViHanhChinh? DonViHanhChinhCha { get; set; }

    public virtual ICollection<AlumniDonViHanhChinh> InverseDonViHanhChinhCha { get; set; } = new List<AlumniDonViHanhChinh>();

    public virtual AlumniLoaiDonViHanhChinh LoaiDonViHanhChinh { get; set; } = null!;

    public virtual AlumniQuocGium? QuocGia { get; set; }
}
