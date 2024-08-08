using System;
using System.Collections.Generic;

namespace DemoProject.Server.Models;

public partial class AlumniThongTinDaoTao
{
    public Guid Id { get; set; }

    public Guid CuuSvId { get; set; }

    public string NienKhoa { get; set; } = null!;

    public string MaKhoaHoc { get; set; } = null!;

    public string TenKhoaHoc { get; set; } = null!;

    public string MaNganhHoc { get; set; } = null!;

    public string TenNganhHoc { get; set; } = null!;

    public string? HinhThucDaoTao { get; set; }

    public string? LopSv { get; set; }

    public string? ChucVu { get; set; }

    /// <summary>
    /// đối tượng tuyển sinh: thương binh liệt sĩ, nhà nghèo,..
    /// </summary>
    public string? DoiTuong { get; set; }

    /// <summary>
    /// trường học cấp 3
    /// </summary>
    public string? Thptlop12 { get; set; }

    public string? MaChuyenNganh { get; set; }

    public string? TenChuyenNganh { get; set; }

    public int NamTotNghiep { get; set; }

    public string? SoQuyetDinh { get; set; }

    public DateOnly? NgayKyQuyetDinh { get; set; }

    public string? NguoiKyQuyetDinh { get; set; }

    public string? ChucVuNguoiKy { get; set; }

    public string? NgonNguDaoTao { get; set; }

    /// <summary>
    /// số vào sổ gốc cấp bằng
    /// </summary>
    public string? SoVaoSoGocCapBang { get; set; }

    public string? SoHieuVanBang { get; set; }

    public string? MaKhoaHocTiengAnh { get; set; }

    public string? TenKhoaHocTiengAnh { get; set; }

    public string? MaNganhHocTiengAnh { get; set; }

    public string? TenNganhHocTiengAnh { get; set; }

    public string? HinhThucDaoTaoTiengAnh { get; set; }

    /// <summary>
    /// hướng đào tạo: nghiên cứu hoặc ứng dụng
    /// </summary>
    public string? HuongDaoTao { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<AlumniKetQuaDaoTao> AlumniKetQuaDaoTaos { get; set; } = new List<AlumniKetQuaDaoTao>();

    public virtual ICollection<AlumniQuyetDinhDaoTao> AlumniQuyetDinhDaoTaos { get; set; } = new List<AlumniQuyetDinhDaoTao>();

    public virtual ICollection<AlumniVanBang> AlumniVanBangs { get; set; } = new List<AlumniVanBang>();

    public virtual AlumniCuuSv CuuSv { get; set; } = null!;
}
