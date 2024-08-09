using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

/// <summary>
/// danh sách các trường có triển khai hệ thống theo dấu SV tốt nghiệp
/// </summary>
public partial class AlumniThongTinTruong
{
    public Guid Id { get; set; }

    public string MaTruong { get; set; } = null!;

    public string? TenTruong { get; set; }

    public string? MoTa { get; set; }

    public string? MoTaChiTiet { get; set; }

    /// <summary>
    /// lưu đường dẫn của hình logo
    /// </summary>
    public string? Logo { get; set; }

    public string? DiaChi { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<AlumniChucNang> AlumniChucNangs { get; set; } = new List<AlumniChucNang>();

    public virtual ICollection<AlumniCuuSv> AlumniCuuSvs { get; set; } = new List<AlumniCuuSv>();

    public virtual ICollection<AlumniHoSoNhanVien> AlumniHoSoNhanViens { get; set; } = new List<AlumniHoSoNhanVien>();

    public virtual ICollection<AlumniNhomQuyen> AlumniNhomQuyens { get; set; } = new List<AlumniNhomQuyen>();

    public virtual ICollection<AlumniTaiKhoanNhanVienTruongTrucThuoc> AlumniTaiKhoanNhanVienTruongTrucThuocs { get; set; } = new List<AlumniTaiKhoanNhanVienTruongTrucThuoc>();

    public virtual ICollection<AlumniThongTinKhoa> AlumniThongTinKhoas { get; set; } = new List<AlumniThongTinKhoa>();

    public virtual ICollection<AlumniThongTinQuyQuyenGop> AlumniThongTinQuyQuyenGops { get; set; } = new List<AlumniThongTinQuyQuyenGop>();

    public virtual ICollection<AlumniThongTinSuKien> AlumniThongTinSuKiens { get; set; } = new List<AlumniThongTinSuKien>();
}
