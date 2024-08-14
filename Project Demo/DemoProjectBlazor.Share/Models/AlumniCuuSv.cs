using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

public partial class AlumniCuuSv
{
    public Guid Id { get; set; }

    public Guid? TruongId { get; set; }

	public virtual AlumniThongTinTruong? Truong { get; set; }
	public string? MaSoSv { get; set; }

    public string HoCuuSv { get; set; } = null!;

    public string TenCuuSv { get; set; } = null!;

    public string? HoTenCuuSv { get; set; }

    /// <summary>
    /// có thể là CMND, CCCD hoặc hộ chiếu
    /// </summary>
    public string MaDinhDanh { get; set; } = null!;

    /// <summary>
    /// F: female - Nữ
    /// M: male - Nam
    /// U: unisex - Phi giới tính
    /// </summary>
    public string GioiTinh { get; set; } = null!;

    public string? Email { get; set; }
	

	public string? DanToc { get; set; }

    public string? TonGiao { get; set; }

    public Guid? QuocGiaId { get; set; }

    public Guid? TinhThanhId { get; set; }

    public Guid? QuanHuyenId { get; set; }

    public Guid? XaPhuongId { get; set; }

    public string? DiaChiLienHe { get; set; }

    public string? HinhAnhDaiDien { get; set; }

    public string? ThamGiaDoan { get; set; }

    public DateTime? NgayVaoDoan { get; set; }

    public string? ThamGiaDang { get; set; }

    public DateTime? NgayVaoDang { get; set; }

    public string? SoDienThoai { get; set; }

    public string? QuocTich { get; set; }

    public string? NgaySinh { get; set; }

    public string? NoiSinh { get; set; }

    /// <summary>
    /// xác định thông tin cựu SV có được sử dụng / hiển thị trên hệ thống hay không
    /// 1: Sử dụng
    /// 0: Không được sử dụng
    /// </summary>
    public bool? SuDung { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<AlumniQuyetDinhDaoTao> AlumniQuyetDinhDaoTaos { get; set; } = new List<AlumniQuyetDinhDaoTao>();

    public virtual ICollection<AlumniTaikhoan> AlumniTaikhoans { get; set; } = new List<AlumniTaikhoan>();

    public virtual ICollection<AlumniThongTinDaoTao> AlumniThongTinDaoTaos { get; set; } = new List<AlumniThongTinDaoTao>();

    public virtual ICollection<AlumniThuTuc> AlumniThuTucs { get; set; } = new List<AlumniThuTuc>();

    public virtual ICollection<AlumniViecLam> AlumniViecLams { get; set; } = new List<AlumniViecLam>();

    public virtual AlumniDonViHanhChinh? QuanHuyen { get; set; }

    public virtual AlumniQuocGium? QuocGia { get; set; }

    public virtual AlumniDonViHanhChinh? TinhThanh { get; set; }

    public virtual AlumniDonViHanhChinh? XaPhuong { get; set; }
}
