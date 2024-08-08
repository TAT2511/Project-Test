using System;
using System.Collections.Generic;

namespace DemoProject.Server.Models;

public partial class AlumniTaikhoan
{
    public Guid Id { get; set; }

    /// <summary>
    /// dùng để lưu thông tin nhận diện giữa các tài khoản của các trường
    /// Thông tin này được cung cấp từ CAAS hoặc từ DB Master
    /// Trong trường hợp không có DB Master, thì TenDangNhap được quản lý bởi client
    /// </summary>
    public string TenDangNhap { get; set; } = null!;

    public string? MatKhau { get; set; }

    public Guid? NhanVienId { get; set; }

    public Guid? CuuSvId { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    /// <summary>
    /// xác định tài khoản có bị khóa hay không
    /// 1: Bị khóa
    /// 0: không bị khóa
    /// </summary>
    public bool? KhoaTaiKhoan { get; set; }

    public virtual ICollection<AlumniDangKySuKien> AlumniDangKySuKiens { get; set; } = new List<AlumniDangKySuKien>();

    public virtual ICollection<AlumniDanhGiaSuKien> AlumniDanhGiaSuKiens { get; set; } = new List<AlumniDanhGiaSuKien>();

    public virtual ICollection<AlumniLichSuDongGop> AlumniLichSuDongGops { get; set; } = new List<AlumniLichSuDongGop>();

    public virtual ICollection<AlumniTaiKhoanChucNang> AlumniTaiKhoanChucNangs { get; set; } = new List<AlumniTaiKhoanChucNang>();

    public virtual ICollection<AlumniTaiKhoanNhanVienTruongTrucThuoc> AlumniTaiKhoanNhanVienTruongTrucThuocs { get; set; } = new List<AlumniTaiKhoanNhanVienTruongTrucThuoc>();

    public virtual ICollection<AlumniTaiKhoanNhomQuyen> AlumniTaiKhoanNhomQuyens { get; set; } = new List<AlumniTaiKhoanNhomQuyen>();

    public virtual ICollection<AlumniThongTinGiaoDich> AlumniThongTinGiaoDichTaiKhoanNhans { get; set; } = new List<AlumniThongTinGiaoDich>();

    public virtual ICollection<AlumniThongTinGiaoDich> AlumniThongTinGiaoDichTaiKhoans { get; set; } = new List<AlumniThongTinGiaoDich>();

    public virtual AlumniCuuSv? CuuSv { get; set; }

    public virtual AlumniNhanVien? NhanVien { get; set; }
}
