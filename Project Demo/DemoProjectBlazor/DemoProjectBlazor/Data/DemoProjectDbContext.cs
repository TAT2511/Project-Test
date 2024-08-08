using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Server.Models;

public partial class DemoProjectDbContext : DbContext
{
    public DemoProjectDbContext()
    {
    }

    public DemoProjectDbContext(DbContextOptions<DemoProjectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlumniChiTietSuKien> AlumniChiTietSuKiens { get; set; }

    public virtual DbSet<AlumniChucNang> AlumniChucNangs { get; set; }

    public virtual DbSet<AlumniChucNangNhomQuyen> AlumniChucNangNhomQuyens { get; set; }

    public virtual DbSet<AlumniCuuSv> AlumniCuuSvs { get; set; }

    public virtual DbSet<AlumniDangKyChiTietSuKien> AlumniDangKyChiTietSuKiens { get; set; }

    public virtual DbSet<AlumniDangKySuKien> AlumniDangKySuKiens { get; set; }

    public virtual DbSet<AlumniDanhGiaSuKien> AlumniDanhGiaSuKiens { get; set; }

    public virtual DbSet<AlumniDonViHanhChinh> AlumniDonViHanhChinhs { get; set; }

    public virtual DbSet<AlumniHoSoNhanVien> AlumniHoSoNhanViens { get; set; }

    public virtual DbSet<AlumniKetQuaDaoTao> AlumniKetQuaDaoTaos { get; set; }

    public virtual DbSet<AlumniKetQuaDaoTaoChiTiet> AlumniKetQuaDaoTaoChiTiets { get; set; }

    public virtual DbSet<AlumniLichSuDongGop> AlumniLichSuDongGops { get; set; }

    public virtual DbSet<AlumniLoaiDonViHanhChinh> AlumniLoaiDonViHanhChinhs { get; set; }

    public virtual DbSet<AlumniNhanVien> AlumniNhanViens { get; set; }

    public virtual DbSet<AlumniNhomQuyen> AlumniNhomQuyens { get; set; }

    public virtual DbSet<AlumniQuocGium> AlumniQuocGia { get; set; }

    public virtual DbSet<AlumniQuyetDinhDaoTao> AlumniQuyetDinhDaoTaos { get; set; }

    public virtual DbSet<AlumniTaiKhoanChucNang> AlumniTaiKhoanChucNangs { get; set; }

    public virtual DbSet<AlumniTaiKhoanNhanVienTruongTrucThuoc> AlumniTaiKhoanNhanVienTruongTrucThuocs { get; set; }

    public virtual DbSet<AlumniTaiKhoanNhomQuyen> AlumniTaiKhoanNhomQuyens { get; set; }

    public virtual DbSet<AlumniTaikhoan> AlumniTaikhoans { get; set; }

    public virtual DbSet<AlumniThongTinDaoTao> AlumniThongTinDaoTaos { get; set; }

    public virtual DbSet<AlumniThongTinGiaoDich> AlumniThongTinGiaoDiches { get; set; }

    public virtual DbSet<AlumniThongTinKhoa> AlumniThongTinKhoas { get; set; }

    public virtual DbSet<AlumniThongTinQuyQuyenGop> AlumniThongTinQuyQuyenGops { get; set; }

    public virtual DbSet<AlumniThongTinSuKien> AlumniThongTinSuKiens { get; set; }

    public virtual DbSet<AlumniThongTinTruong> AlumniThongTinTruongs { get; set; }

    public virtual DbSet<AlumniThuTuc> AlumniThuTucs { get; set; }

    public virtual DbSet<AlumniVanBang> AlumniVanBangs { get; set; }

    public virtual DbSet<AlumniViecLam> AlumniViecLams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PSC_Alumni;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlumniChiTietSuKien>(entity =>
        {
            entity.ToTable("Alumni_ChiTietSuKien");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            entity.Property(e => e.SuKienId).HasColumnName("SuKien_Id");
            entity.Property(e => e.TenChiTietSuKien).HasMaxLength(500);

            entity.HasOne(d => d.SuKien).WithMany(p => p.AlumniChiTietSuKiens)
                .HasForeignKey(d => d.SuKienId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_ChiTietSuKien_Alumni_ThongTinSuKien");
        });

        modelBuilder.Entity<AlumniChucNang>(entity =>
        {
            entity.ToTable("Alumni_ChucNang");

            entity.HasIndex(e => e.Id, "IX_Alumni_ChucNang").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MaChucNang)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TenChucNang).HasMaxLength(1000);
            entity.Property(e => e.TruongId).HasColumnName("Truong_Id");

            entity.HasOne(d => d.Truong).WithMany(p => p.AlumniChucNangs)
                .HasForeignKey(d => d.TruongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_ChucNang_Alumni_ThongTinTruong");
        });

        modelBuilder.Entity<AlumniChucNangNhomQuyen>(entity =>
        {
            entity.ToTable("Alumni_ChucNang_NhomQuyen");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ChucNangId).HasColumnName("ChucNang_Id");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.NhomQuyenId).HasColumnName("NhomQuyen_Id");

            entity.HasOne(d => d.ChucNang).WithMany(p => p.AlumniChucNangNhomQuyens)
                .HasForeignKey(d => d.ChucNangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_ChucNang_NhomQuyen_Alumni_ChucNang");

            entity.HasOne(d => d.NhomQuyen).WithMany(p => p.AlumniChucNangNhomQuyens)
                .HasForeignKey(d => d.NhomQuyenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_ChucNang_NhomQuyen_Alumni_NhomQuyen");
        });

        modelBuilder.Entity<AlumniCuuSv>(entity =>
        {
            entity.ToTable("Alumni_CuuSV");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DanToc).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DiaChiLienHe).HasMaxLength(1000);
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasComment("F: female - Nữ\r\nM: male - Nam\r\nU: unisex - Phi giới tính");
            entity.Property(e => e.HinhAnhDaiDien).IsUnicode(false);
            entity.Property(e => e.HoCuuSv)
                .HasMaxLength(255)
                .HasColumnName("Ho_CuuSV");
            entity.Property(e => e.HoTenCuuSv)
                .HasMaxLength(1000)
                .HasColumnName("HoTen_CuuSV");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MaDinhDanh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("có thể là CMND, CCCD hoặc hộ chiếu");
            entity.Property(e => e.MaSoSv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaSoSV");
            entity.Property(e => e.NgaySinh)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NgayVaoDang).HasColumnType("datetime");
            entity.Property(e => e.NgayVaoDoan).HasColumnType("datetime");
            entity.Property(e => e.NoiSinh).HasMaxLength(500);
            entity.Property(e => e.QuanHuyenId).HasColumnName("QuanHuyen_Id");
            entity.Property(e => e.QuocGiaId).HasColumnName("QuocGia_Id");
            entity.Property(e => e.QuocTich).HasMaxLength(255);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SuDung).HasComment("xác định thông tin cựu SV có được sử dụng / hiển thị trên hệ thống hay không\r\n1: Sử dụng\r\n0: Không được sử dụng");
            entity.Property(e => e.TenCuuSv)
                .HasMaxLength(500)
                .HasColumnName("Ten_CuuSV");
            entity.Property(e => e.ThamGiaDang).HasMaxLength(255);
            entity.Property(e => e.ThamGiaDoan).HasMaxLength(255);
            entity.Property(e => e.TinhThanhId).HasColumnName("TinhThanh_Id");
            entity.Property(e => e.TonGiao).HasMaxLength(255);
            entity.Property(e => e.TruongId).HasColumnName("Truong_Id");
            entity.Property(e => e.XaPhuongId).HasColumnName("XaPhuong_Id");

            entity.HasOne(d => d.QuanHuyen).WithMany(p => p.AlumniCuuSvQuanHuyens)
                .HasForeignKey(d => d.QuanHuyenId)
                .HasConstraintName("FK_Alumni_CuuSV_Alumni_DonViHanhChinh1");

            entity.HasOne(d => d.QuocGia).WithMany(p => p.AlumniCuuSvs)
                .HasForeignKey(d => d.QuocGiaId)
                .HasConstraintName("FK_Alumni_CuuSV_Alumni_QuocGia");

            entity.HasOne(d => d.TinhThanh).WithMany(p => p.AlumniCuuSvTinhThanhs)
                .HasForeignKey(d => d.TinhThanhId)
                .HasConstraintName("FK_Alumni_CuuSV_Alumni_DonViHanhChinh");

            entity.HasOne(d => d.Truong).WithMany(p => p.AlumniCuuSvs)
                .HasForeignKey(d => d.TruongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_CuuSV_Alumni_ThongTinTruong");

            entity.HasOne(d => d.XaPhuong).WithMany(p => p.AlumniCuuSvXaPhuongs)
                .HasForeignKey(d => d.XaPhuongId)
                .HasConstraintName("FK_Alumni_CuuSV_Alumni_DonViHanhChinh2");
        });

        modelBuilder.Entity<AlumniDangKyChiTietSuKien>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Alumni_DangKy_ChiTietSuKien");

            entity.Property(e => e.ChiTietSuKienId).HasColumnName("ChiTietSuKien_Id");
            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.TaiKhoanId).HasColumnName("TaiKhoan_Id");
        });

        modelBuilder.Entity<AlumniDangKySuKien>(entity =>
        {
            entity.ToTable("Alumni_DangKySuKien");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DiemDanhSuKien).HasColumnType("datetime");
            entity.Property(e => e.GiaVe).HasColumnType("decimal(15, 3)");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.LyDoHuyDangKy).HasMaxLength(1000);
            entity.Property(e => e.NgayDangKy).HasColumnType("datetime");
            entity.Property(e => e.NgayHuyDangKy)
                .HasComment("Ghi nhận ngày hủy tham gia sự kiện")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayThamGiaSuKien)
                .HasComment("Ngày tham gia sự kiện có thể khác ngày bắt đầu sự kiện đối với những sự kiện diễn ra trong nhiều ngày")
                .HasColumnType("datetime");
            entity.Property(e => e.SuKienId).HasColumnName("SuKien_Id");
            entity.Property(e => e.TaiKhoanId).HasColumnName("TaiKhoan_Id");
            entity.Property(e => e.TongSoTienVe).HasColumnType("decimal(15, 3)");
            entity.Property(e => e.TrangThaiThanhToan).HasComment("ghi nhận trạng thái thanh toán giá vé\r\n1 - miễn phí\r\n2 - chưa thanh toán\r\n3 - thanh toán sau\r\n4 - đã thanh toán\r\n");

            entity.HasOne(d => d.SuKien).WithMany(p => p.AlumniDangKySuKiens)
                .HasForeignKey(d => d.SuKienId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_DangKySuKien_Alumni_ThongTinSuKien");

            entity.HasOne(d => d.TaiKhoan).WithMany(p => p.AlumniDangKySuKiens)
                .HasForeignKey(d => d.TaiKhoanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_DangKySuKien_Alumni_Taikhoan");
        });

        modelBuilder.Entity<AlumniDanhGiaSuKien>(entity =>
        {
            entity.ToTable("Alumni_DanhGiaSuKien");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DiemDanhGia).HasComment("Rating:  thang điểm từ 1 - 5");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.NgayDanhGia).HasColumnType("datetime");
            entity.Property(e => e.SuKienId).HasColumnName("SuKien_Id");
            entity.Property(e => e.TaiKhoanId).HasColumnName("TaiKhoan_Id");
            entity.Property(e => e.TenNguoiDanhGia).HasMaxLength(255);

            entity.HasOne(d => d.SuKien).WithMany(p => p.AlumniDanhGiaSuKiens)
                .HasForeignKey(d => d.SuKienId)
                .HasConstraintName("FK_Alumni_DanhGiaSuKien_Alumni_ThongTinSuKien");

            entity.HasOne(d => d.TaiKhoan).WithMany(p => p.AlumniDanhGiaSuKiens)
                .HasForeignKey(d => d.TaiKhoanId)
                .HasConstraintName("FK_Alumni_DanhGiaSuKien_Alumni_Taikhoan");
        });

        modelBuilder.Entity<AlumniDonViHanhChinh>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alumni_D__3214EC270F288BBC");

            entity.ToTable("Alumni_DonViHanhChinh", tb => tb.HasComment("Các đơn vị hành chính thuộc về 1 đơn vị hành chính khác thì sẽ có giá trị đơn vị hành chính cha (VD: tỉnh thành phố -> quận huyện, quận huyện -> xã phường)"));

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DonViHanhChinhChaId).HasColumnName("DonViHanhChinhCha_Id");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.LoaiDonViHanhChinhId).HasColumnName("LoaiDonViHanhChinh_Id");
            entity.Property(e => e.MaDonViHanhChinh)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.QuocGiaId).HasColumnName("QuocGia_Id");
            entity.Property(e => e.TenDonViHanhChinh).HasMaxLength(500);

            entity.HasOne(d => d.DonViHanhChinhCha).WithMany(p => p.InverseDonViHanhChinhCha)
                .HasForeignKey(d => d.DonViHanhChinhChaId)
                .HasConstraintName("FK_Alumni_DonViHanhChinh_Cha_Alumni_DonViHanhChinh");

            entity.HasOne(d => d.LoaiDonViHanhChinh).WithMany(p => p.AlumniDonViHanhChinhs)
                .HasForeignKey(d => d.LoaiDonViHanhChinhId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_DonViHanhChinh_Alumni_LoaiDonViHanhChinh");

            entity.HasOne(d => d.QuocGia).WithMany(p => p.AlumniDonViHanhChinhs)
                .HasForeignKey(d => d.QuocGiaId)
                .HasConstraintName("FK_Alumni_DonViHanhChinh_Alumni_QuocGia");
        });

        modelBuilder.Entity<AlumniHoSoNhanVien>(entity =>
        {
            entity.ToTable("Alumni_HoSoNhanVien", tb => tb.HasComment("quản lý thông tin hồ sơ của giảng viên / nhân viên tại 1 trường cụ thể"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DienThoaiLienHe)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.HinhThucHopDong)
                .HasMaxLength(255)
                .HasComment("các hình thức hợp đồng:\r\n- Viên chức HĐLV không xác định thời hạn\r\n- Viên chức HĐLV xác định thời hạn -> 1 năm , 2 năm....");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.NgayTuyenDung).HasColumnType("datetime");
            entity.Property(e => e.NhanVienId).HasColumnName("NhanVien_Id");
            entity.Property(e => e.TruongTrucThuocId).HasColumnName("TruongTrucThuoc_Id");
            entity.Property(e => e.ViTri)
                .HasMaxLength(500)
                .HasComment("vị trí công tác của nhân viên tại trường đại học");

            entity.HasOne(d => d.NhanVien).WithMany(p => p.AlumniHoSoNhanViens)
                .HasForeignKey(d => d.NhanVienId)
                .HasConstraintName("FK_Alumni_HoSoNhanVien_Alumni_NhanVien");

            entity.HasOne(d => d.TruongTrucThuoc).WithMany(p => p.AlumniHoSoNhanViens)
                .HasForeignKey(d => d.TruongTrucThuocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_HoSoNhanVien_Alumni_ThongTinTruong");
        });

        modelBuilder.Entity<AlumniKetQuaDaoTao>(entity =>
        {
            entity.ToTable("Alumni_KetQuaDaoTao");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CuuSvId).HasColumnName("CuuSV_Id");
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DiemRenLuyen).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DiemTbHe10)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("DiemTB_He10");
            entity.Property(e => e.DiemTbHe4)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("DiemTB_He4");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.TcTichLuy)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TC_TichLuy");
            entity.Property(e => e.TcTongSo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TC_TongSo");
            entity.Property(e => e.ThongTinDaoTaoId).HasColumnName("ThongTinDaoTao_Id");
            entity.Property(e => e.XepLoai)
                .HasMaxLength(50)
                .HasComment("xếp loại dựa trên điểm học tập");
            entity.Property(e => e.XepLoaiRenLuyen)
                .HasMaxLength(50)
                .HasComment("xếp loại dựa trên điểm rèn luyện");

            entity.HasOne(d => d.ThongTinDaoTao).WithMany(p => p.AlumniKetQuaDaoTaos)
                .HasForeignKey(d => d.ThongTinDaoTaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_KetQuaDaoTao_Alumni_ThongTinDaoTao");
        });

        modelBuilder.Entity<AlumniKetQuaDaoTaoChiTiet>(entity =>
        {
            entity.ToTable("Alumni_KetQuaDaoTao_ChiTiet");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DiemChu).HasMaxLength(255);
            entity.Property(e => e.DiemHe10)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Diem_He10");
            entity.Property(e => e.DiemHe4)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Diem_He4");
            entity.Property(e => e.KetQua).HasMaxLength(255);
            entity.Property(e => e.KetQuaDaoTaoId).HasColumnName("KetQuaDaoTao_Id");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MaMonHoc).HasMaxLength(255);
            entity.Property(e => e.SoTc)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("SoTC");
            entity.Property(e => e.TenMonHoc).HasMaxLength(1000);

            entity.HasOne(d => d.KetQuaDaoTao).WithMany(p => p.AlumniKetQuaDaoTaoChiTiets)
                .HasForeignKey(d => d.KetQuaDaoTaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_KetQuaDaoTao_ChiTiet_Alumni_KetQuaDaoTao");
        });

        modelBuilder.Entity<AlumniLichSuDongGop>(entity =>
        {
            entity.ToTable("Alumni_LichSuDongGop");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DiaDiemDongGop).HasMaxLength(1000);
            entity.Property(e => e.DonViNhanDongGop).HasMaxLength(500);
            entity.Property(e => e.HienVatDongGop).HasMaxLength(1000);
            entity.Property(e => e.HinhAnhDinhKem)
                .IsUnicode(false)
                .HasComment("trong trường hợp nhận hiện vật có thể cần chụp hình để ghi nhận làm bằng chứng");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.NgayDongGop).HasColumnType("datetime");
            entity.Property(e => e.NguoiNhanDongGop).HasMaxLength(1000);
            entity.Property(e => e.QuyQuyenGopId).HasColumnName("QuyQuyenGop_Id");
            entity.Property(e => e.SoTienDongGop).HasColumnType("decimal(15, 3)");
            entity.Property(e => e.TaiKhoanId).HasColumnName("TaiKhoan_Id");
            entity.Property(e => e.TaiKhoanNhanDongGopId).HasColumnName("TaiKhoanNhanDongGop_Id");

            entity.HasOne(d => d.QuyQuyenGop).WithMany(p => p.AlumniLichSuDongGops)
                .HasForeignKey(d => d.QuyQuyenGopId)
                .HasConstraintName("FK_Alumni_LichSuDongGop_Alumni_ThongTinQuyQuyenGop");

            entity.HasOne(d => d.TaiKhoan).WithMany(p => p.AlumniLichSuDongGops)
                .HasForeignKey(d => d.TaiKhoanId)
                .HasConstraintName("FK_Alumni_LichSuDongGop_Alumni_Taikhoan");
        });

        modelBuilder.Entity<AlumniLoaiDonViHanhChinh>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alumni_L__3214EC279D83A301");

            entity.ToTable("Alumni_LoaiDonViHanhChinh", tb => tb.HasComment("Quản lý danh sách các loại đơn vị hành chính: tỉnh, thành, phố, quận, huyện, xã, phường"));

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MaLoaiDonViHanhChinh)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TenLoaiDonViHanhChinh).HasMaxLength(255);
        });

        modelBuilder.Entity<AlumniNhanVien>(entity =>
        {
            entity.ToTable("Alumni_NhanVien", tb => tb.HasComment("quản lý thông tin của giảng viên / nhân viên ở cấp cao nhất.\r\nthông tin này là duy nhất đối với 1 người giảng viên / nhân viên"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DanTocId).HasColumnName("DanToc_Id");
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasComment("F: feamle - nữ\r\nM: male - nam");
            entity.Property(e => e.HoNhanVien)
                .HasMaxLength(255)
                .HasColumnName("Ho_NhanVien");
            entity.Property(e => e.HoTenNhanVien)
                .HasMaxLength(1000)
                .HasColumnName("HoTen_NhanVien");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MaDinhDanh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("có thể là CMND, CCCD hoặc hộ chiếu");
            entity.Property(e => e.MaTruongQuanLy)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("mã của trường cấp cao nhất");
            entity.Property(e => e.QuanHuyenThuongTruId).HasColumnName("QuanHuyenThuongTru_Id");
            entity.Property(e => e.QueQuan).HasMaxLength(255);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TenNhanVien)
                .HasMaxLength(500)
                .HasColumnName("Ten_NhanVien");
            entity.Property(e => e.TinhThanhPhoThuongTruId).HasColumnName("TinhThanhPhoThuongTru_Id");
            entity.Property(e => e.TonGiao).HasMaxLength(255);
            entity.Property(e => e.XaPhuongThuongTruId).HasColumnName("XaPhuongThuongTru_Id");

            entity.HasOne(d => d.DanToc).WithMany(p => p.AlumniNhanViens)
                .HasForeignKey(d => d.DanTocId)
                .HasConstraintName("FK_Alumni_NhanVien_Alumni_QuocGia");

            entity.HasOne(d => d.QuanHuyenThuongTru).WithMany(p => p.AlumniNhanVienQuanHuyenThuongTrus)
                .HasForeignKey(d => d.QuanHuyenThuongTruId)
                .HasConstraintName("FK_Alumni_NhanVien_Alumni_DonViHanhChinh");

            entity.HasOne(d => d.TinhThanhPhoThuongTru).WithMany(p => p.AlumniNhanVienTinhThanhPhoThuongTrus)
                .HasForeignKey(d => d.TinhThanhPhoThuongTruId)
                .HasConstraintName("FK_Alumni_NhanVien_Alumni_DonViHanhChinh1");

            entity.HasOne(d => d.XaPhuongThuongTru).WithMany(p => p.AlumniNhanVienXaPhuongThuongTrus)
                .HasForeignKey(d => d.XaPhuongThuongTruId)
                .HasConstraintName("FK_Alumni_NhanVien_Alumni_DonViHanhChinh2");
        });

        modelBuilder.Entity<AlumniNhomQuyen>(entity =>
        {
            entity.ToTable("Alumni_NhomQuyen");

            entity.HasIndex(e => e.Id, "IX_Alumni_NhomQuyen").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.HienThi).HasComment("1: hiển thị\r\n0: không hiển thị\r\n");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MaNhomQuyen).HasMaxLength(255);
            entity.Property(e => e.TenNhomQuyen).HasMaxLength(1000);
            entity.Property(e => e.TruongId).HasColumnName("Truong_Id");

            entity.HasOne(d => d.Truong).WithMany(p => p.AlumniNhomQuyens)
                .HasForeignKey(d => d.TruongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_NhomQuyen_Alumni_ThongTinTruong");
        });

        modelBuilder.Entity<AlumniQuocGium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alumni_Q__3214EC27A97F162E");

            entity.ToTable("Alumni_QuocGia", tb => tb.HasComment("Danh mục từ điển, dùng để quản lý danh sách quốc gia trong hệ thống."));

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MaQuocGia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenQuocGia).HasMaxLength(255);
        });

        modelBuilder.Entity<AlumniQuyetDinhDaoTao>(entity =>
        {
            entity.ToTable("Alumni_QuyetDinhDaoTao");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CuuSvId).HasColumnName("CuuSV_Id");
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.HocKy).HasMaxLength(255);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.LoaiQuyetDinh).HasMaxLength(255);
            entity.Property(e => e.NamHoc).HasMaxLength(100);
            entity.Property(e => e.NgayKy).HasColumnType("datetime");
            entity.Property(e => e.NguoiKy).HasMaxLength(1000);
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(255);
            entity.Property(e => e.ThongTinDaoTaoId).HasColumnName("ThongTinDaoTao_Id");

            entity.HasOne(d => d.CuuSv).WithMany(p => p.AlumniQuyetDinhDaoTaos)
                .HasForeignKey(d => d.CuuSvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_QuyetDinhDaoTao_Alumni_CuuSV");

            entity.HasOne(d => d.ThongTinDaoTao).WithMany(p => p.AlumniQuyetDinhDaoTaos)
                .HasForeignKey(d => d.ThongTinDaoTaoId)
                .HasConstraintName("FK_Alumni_QuyetDinhDaoTao_Alumni_ThongTinDaoTao");
        });

        modelBuilder.Entity<AlumniTaiKhoanChucNang>(entity =>
        {
            entity.ToTable("Alumni_TaiKhoan_ChucNang");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ChucNangId).HasColumnName("ChucNang_Id");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.TaiKhoanId).HasColumnName("TaiKhoan_Id");

            entity.HasOne(d => d.ChucNang).WithMany(p => p.AlumniTaiKhoanChucNangs)
                .HasForeignKey(d => d.ChucNangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_TaiKhoan_ChucNang_Alumni_ChucNang");

            entity.HasOne(d => d.TaiKhoan).WithMany(p => p.AlumniTaiKhoanChucNangs)
                .HasForeignKey(d => d.TaiKhoanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_TaiKhoan_ChucNang_Alumni_Taikhoan");
        });

        modelBuilder.Entity<AlumniTaiKhoanNhanVienTruongTrucThuoc>(entity =>
        {
            entity.HasKey(e => new { e.TaiKhoanId, e.TruongId }).HasName("PK_Alumni_TaiKhoan_TruongTrucThuoc");

            entity.ToTable("Alumni_TaiKhoanNhanVien_TruongTrucThuoc", tb => tb.HasComment("quản lý quyền truy cập của tài khoản vào các trường trưc thuộc\r\ntable này dùng để kiểm tra quyền truy cập nhanh từ màn hình đăng nhập (trường hợp nhiều trường dùng chung 1 DB)"));

            entity.Property(e => e.TaiKhoanId).HasColumnName("TaiKhoan_Id");
            entity.Property(e => e.TruongId).HasColumnName("Truong_Id");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.KhoaTaiKhoan).HasComment("xác định tài khoản có bị khóa hay không ở cấp độ trường trực thuộc\r\n1: Bị khóa\r\n0: không bị khóa");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);

            entity.HasOne(d => d.TaiKhoan).WithMany(p => p.AlumniTaiKhoanNhanVienTruongTrucThuocs)
                .HasForeignKey(d => d.TaiKhoanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_TaiKhoan_TruongTrucThuoc_Alumni_Taikhoan");

            entity.HasOne(d => d.Truong).WithMany(p => p.AlumniTaiKhoanNhanVienTruongTrucThuocs)
                .HasForeignKey(d => d.TruongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_TaiKhoan_TruongTrucThuoc_Alumni_ThongTinTruong");
        });

        modelBuilder.Entity<AlumniTaiKhoanNhomQuyen>(entity =>
        {
            entity.ToTable("Alumni_TaiKhoan_NhomQuyen");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.NhomQuyenId).HasColumnName("NhomQuyen_Id");
            entity.Property(e => e.TaiKhoanId).HasColumnName("TaiKhoan_Id");

            entity.HasOne(d => d.NhomQuyen).WithMany(p => p.AlumniTaiKhoanNhomQuyens)
                .HasForeignKey(d => d.NhomQuyenId)
                .HasConstraintName("FK_Alumni_TaiKhoan_NhomQuyen_Alumni_NhomQuyen");

            entity.HasOne(d => d.TaiKhoan).WithMany(p => p.AlumniTaiKhoanNhomQuyens)
                .HasForeignKey(d => d.TaiKhoanId)
                .HasConstraintName("FK_Alumni_TaiKhoan_NhomQuyen_Alumni_Taikhoan");
        });

        modelBuilder.Entity<AlumniTaikhoan>(entity =>
        {
            entity.ToTable("Alumni_Taikhoan");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CuuSvId).HasColumnName("CuuSV_Id");
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.KhoaTaiKhoan).HasComment("xác định tài khoản có bị khóa hay không\r\n1: Bị khóa\r\n0: không bị khóa");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NhanVienId).HasColumnName("NhanVien_Id");
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasComment("dùng để lưu thông tin nhận diện giữa các tài khoản của các trường\r\nThông tin này được cung cấp từ CAAS hoặc từ DB Master\r\nTrong trường hợp không có DB Master, thì TenDangNhap được quản lý bởi client");

            entity.HasOne(d => d.CuuSv).WithMany(p => p.AlumniTaikhoans)
                .HasForeignKey(d => d.CuuSvId)
                .HasConstraintName("FK_Alumni_Taikhoan_Alumni_CuuSV");

            entity.HasOne(d => d.NhanVien).WithMany(p => p.AlumniTaikhoans)
                .HasForeignKey(d => d.NhanVienId)
                .HasConstraintName("FK_Alumni_Taikhoan_Alumni_NhanVien");
        });

        modelBuilder.Entity<AlumniThongTinDaoTao>(entity =>
        {
            entity.ToTable("Alumni_ThongTinDaoTao");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ChucVu).HasMaxLength(255);
            entity.Property(e => e.ChucVuNguoiKy).HasMaxLength(255);
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CuuSvId).HasColumnName("CuuSV_Id");
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DoiTuong)
                .HasMaxLength(255)
                .HasComment("đối tượng tuyển sinh: thương binh liệt sĩ, nhà nghèo,..");
            entity.Property(e => e.HinhThucDaoTao).HasMaxLength(255);
            entity.Property(e => e.HinhThucDaoTaoTiengAnh)
                .HasMaxLength(255)
                .HasColumnName("HinhThucDaoTao_TiengAnh");
            entity.Property(e => e.HuongDaoTao)
                .HasMaxLength(255)
                .HasComment("hướng đào tạo: nghiên cứu hoặc ứng dụng");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.LopSv)
                .HasMaxLength(100)
                .HasColumnName("LopSV");
            entity.Property(e => e.MaChuyenNganh).HasMaxLength(100);
            entity.Property(e => e.MaKhoaHoc).HasMaxLength(100);
            entity.Property(e => e.MaKhoaHocTiengAnh)
                .HasMaxLength(100)
                .HasColumnName("MaKhoaHoc_TiengAnh");
            entity.Property(e => e.MaNganhHoc).HasMaxLength(100);
            entity.Property(e => e.MaNganhHocTiengAnh)
                .HasMaxLength(100)
                .HasColumnName("MaNganhHoc_TiengAnh");
            entity.Property(e => e.NgonNguDaoTao).HasMaxLength(50);
            entity.Property(e => e.NguoiKyQuyetDinh).HasMaxLength(255);
            entity.Property(e => e.NienKhoa).HasMaxLength(100);
            entity.Property(e => e.SoHieuVanBang)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(50);
            entity.Property(e => e.SoVaoSoGocCapBang)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("số vào sổ gốc cấp bằng");
            entity.Property(e => e.TenChuyenNganh).HasMaxLength(1000);
            entity.Property(e => e.TenKhoaHoc).HasMaxLength(1000);
            entity.Property(e => e.TenKhoaHocTiengAnh)
                .HasMaxLength(1000)
                .HasColumnName("TenKhoaHoc_TiengAnh");
            entity.Property(e => e.TenNganhHoc).HasMaxLength(1000);
            entity.Property(e => e.TenNganhHocTiengAnh)
                .HasMaxLength(1000)
                .HasColumnName("TenNganhHoc_TiengAnh");
            entity.Property(e => e.Thptlop12)
                .HasMaxLength(255)
                .HasComment("trường học cấp 3")
                .HasColumnName("THPTLop12");

            entity.HasOne(d => d.CuuSv).WithMany(p => p.AlumniThongTinDaoTaos)
                .HasForeignKey(d => d.CuuSvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_ThongTinDaoTao_Alumni_CuuSV");
        });

        modelBuilder.Entity<AlumniThongTinGiaoDich>(entity =>
        {
            entity.ToTable("Alumni_ThongTinGiaoDich");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DangKySuKienId).HasColumnName("DangKySuKien_Id");
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DonViNhan).HasMaxLength(500);
            entity.Property(e => e.DongGopQuyenGopId).HasColumnName("DongGopQuyenGop_Id");
            entity.Property(e => e.EmailNguoiThucHien)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Email_NguoiThucHien");
            entity.Property(e => e.HinhThuc).HasComment("1 - tiền mặt\r\n2 - chuyển khoản");
            entity.Property(e => e.HoTenNguoiThucHien)
                .HasMaxLength(1000)
                .HasColumnName("HoTen_NguoiThucHien");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MaGiaoDich)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NgayNhanKetQua)
                .HasComment("ngày bên nhà trường xác nhận đã nhận được tiền")
                .HasColumnType("datetime")
                .HasColumnName("Ngay_NhanKetQua");
            entity.Property(e => e.NgayThucHien).HasColumnType("datetime");
            entity.Property(e => e.SoDienThoaiNguoiThucHien)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SoDienThoai_NguoiThucHien");
            entity.Property(e => e.SoTien)
                .HasComment("Số tiền yêu cầu thực hiện")
                .HasColumnType("decimal(15, 3)");
            entity.Property(e => e.SoTienGiaoDich)
                .HasComment("số tiền thực tế đã thực hiện")
                .HasColumnType("decimal(15, 3)");
            entity.Property(e => e.TaiKhoanId).HasColumnName("TaiKhoan_Id");
            entity.Property(e => e.TaiKhoanNhanId).HasColumnName("TaiKhoanNhan_Id");
            entity.Property(e => e.TenNguoiNhan)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.TrangThai).HasComment("Trạng thái giao dịch\r\n1 - Mới (mới tạo thông tin)\r\n2 - Đang xử lý\r\n3 - Hoàn Thành\r\n4 - Hủy ( vì lý do gi đó giao dịch bị hủy)");

            entity.HasOne(d => d.DangKySuKien).WithMany(p => p.AlumniThongTinGiaoDiches)
                .HasForeignKey(d => d.DangKySuKienId)
                .HasConstraintName("FK_Alumni_ThongTinGiaoDich_Alumni_DangKySuKien");

            entity.HasOne(d => d.DongGopQuyenGop).WithMany(p => p.AlumniThongTinGiaoDiches)
                .HasForeignKey(d => d.DongGopQuyenGopId)
                .HasConstraintName("FK_Alumni_ThongTinGiaoDich_Alumni_LichSuDongGop");

            entity.HasOne(d => d.TaiKhoan).WithMany(p => p.AlumniThongTinGiaoDichTaiKhoans)
                .HasForeignKey(d => d.TaiKhoanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_ThongTinGiaoDich_Alumni_Taikhoan");

            entity.HasOne(d => d.TaiKhoanNhan).WithMany(p => p.AlumniThongTinGiaoDichTaiKhoanNhans)
                .HasForeignKey(d => d.TaiKhoanNhanId)
                .HasConstraintName("FK_Alumni_ThongTinGiaoDich_Alumni_Taikhoan1");
        });

        modelBuilder.Entity<AlumniThongTinKhoa>(entity =>
        {
            entity.ToTable("Alumni_ThongTinKhoa");

            entity.HasIndex(e => e.MaKhoa, "IX_Alumni_ThongTinKhoa").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TenKhoa).HasMaxLength(255);
            entity.Property(e => e.TruongId).HasColumnName("Truong_Id");

            entity.HasOne(d => d.Truong).WithMany(p => p.AlumniThongTinKhoas)
                .HasForeignKey(d => d.TruongId)
                .HasConstraintName("FK_Alumni_ThongTinKhoa_Alumni_ThongTinTruong");
        });

        modelBuilder.Entity<AlumniThongTinQuyQuyenGop>(entity =>
        {
            entity.ToTable("Alumni_ThongTinQuyQuyenGop", tb => tb.HasComment("1: hiện vật\r\n2: hiện kim"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CongBoQuyQuyenGop).HasComment("Xác định quỹ quyên góp publish cho người dùng cuối được phép thấy thông tin và tiến hành quyên góp\r\n1 - công bố\r\n0 - chưa công bố");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DiaDiemQuyenGop).HasMaxLength(1000);
            entity.Property(e => e.HanMucQuyenGop)
                .HasComment("trường hợp quyên góp hình thức là hiện kim, thì admin có thể setup hạn mức quyên góp. khi số tiền quyên góp đạt mức hạn mức , có thể tự động chuyển trạng thái sang \"Hết hạn quyên góp\" hoặc \"Ngưng tiếp nhận quyên góp\"")
                .HasColumnType("decimal(15, 0)");
            entity.Property(e => e.HinhAnhMaQrcode)
                .IsUnicode(false)
                .HasComment("trong trường hợp người quyên góp thực hiện chuyển khoản thì bên phía nhà trường cung cấp mã QR Code để người quyên góp có thể scan nếu có nhu cầu")
                .HasColumnName("HinhAnhMaQRCode");
            entity.Property(e => e.HinhThucQuyenGop).HasComment("xác định hình thức quyên góp\r\n1 - Hiện vật\r\n2 - hiện kim");
            entity.Property(e => e.KhoaQuyQuyenGop).HasComment("xác định quỹ quyên góp có bị khóa hay không\r\n1 - locked\r\n0 - unlocked");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MaQuyQuyenGop).HasMaxLength(100);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.MucTieuQuyenGop)
                .HasMaxLength(1000)
                .HasComment("Mục tiêu của quỹ quyên góp là gi , hạn mức");
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayHetHanQuyenGop).HasColumnType("datetime");
            entity.Property(e => e.NgayHuy).HasColumnType("datetime");
            entity.Property(e => e.NgạyKetThuc).HasColumnType("datetime");
            entity.Property(e => e.QuyetDinhQuyQuyenGop)
                .IsUnicode(false)
                .HasComment("Lưu trữ đường dẫn của file quyết định cho quỹ quyên góp");
            entity.Property(e => e.TaiKhoanNhanQuyenGop)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TenNganHang).HasMaxLength(1000);
            entity.Property(e => e.TenQuyQuyenGop).HasMaxLength(255);
            entity.Property(e => e.TenTaiKhoanNhanQuyenGop)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TieuDe).HasMaxLength(255);
            entity.Property(e => e.TongSoTienQuyenGop).HasColumnType("decimal(15, 3)");
            entity.Property(e => e.TrangThai).HasComment("1 - Chưa bắt đầu, \r\n2 - Đang diễn ra, \r\n3 - Hủy, \r\n4 - Hết hạn quyên góp\r\n5 - Kết thúc quỹ quyên góp");
            entity.Property(e => e.TruongId).HasColumnName("Truong_Id");

            entity.HasOne(d => d.Truong).WithMany(p => p.AlumniThongTinQuyQuyenGops)
                .HasForeignKey(d => d.TruongId)
                .HasConstraintName("FK_Alumni_ThongTinQuyQuyenGop_Alumni_ThongTinTruong");
        });

        modelBuilder.Entity<AlumniThongTinSuKien>(entity =>
        {
            entity.ToTable("Alumni_ThongTinSuKien");

            entity.HasIndex(e => e.MaSuKien, "IX_Alumni_ThongTinSuKien").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CongBoSuKien).HasComment("Xác định sự kiện publish cho người dùng đăng ký sự kiện hay chưa\r\n1: published\r\n0: unpublished");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DiaDiemToChuc).HasMaxLength(1000);
            entity.Property(e => e.GiaVe).HasColumnType("decimal(15, 3)");
            entity.Property(e => e.HinhAnhSuKien).IsUnicode(false);
            entity.Property(e => e.HinhThucBanVe).HasComment("Ghi nhận hình thức loại vé của sự kiện là loại gi\r\n1 - Vé tặng\r\n2 - Mua vé");
            entity.Property(e => e.KhoaId).HasColumnName("Khoa_Id");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.LyDoHuySuKien).HasMaxLength(255);
            entity.Property(e => e.MaSuKien).HasMaxLength(100);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayBatDauDangKy).HasColumnType("datetime");
            entity.Property(e => e.NgayHuySuKien).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThucDangKy).HasColumnType("datetime");
            entity.Property(e => e.TenSuKien).HasMaxLength(255);
            entity.Property(e => e.TieuDe).HasMaxLength(255);
            entity.Property(e => e.TrangThai).HasComment("1 - Chưa diễn ra (sự kiện chưa đến ngày diễn ra),\r\n2 -  Đang diễn ra (sự kiện đang trong thời gian diễn ra), \r\n3 - Hủy (sự kiện bị hủy),\r\n4 - Hết hạn đăng ký (sự kiện hết thời hạn đăng ký)");
            entity.Property(e => e.TruongId).HasColumnName("Truong_Id");

            entity.HasOne(d => d.Khoa).WithMany(p => p.AlumniThongTinSuKiens)
                .HasForeignKey(d => d.KhoaId)
                .HasConstraintName("FK_Alumni_ThongTinSuKien_Alumni_ThongTinKhoa");

            entity.HasOne(d => d.Truong).WithMany(p => p.AlumniThongTinSuKiens)
                .HasForeignKey(d => d.TruongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_ThongTinSuKien_Alumni_ThongTinTruong");
        });

        modelBuilder.Entity<AlumniThongTinTruong>(entity =>
        {
            entity.ToTable("Alumni_ThongTinTruong", tb => tb.HasComment("danh sách các trường có triển khai hệ thống theo dấu SV tốt nghiệp"));

            entity.HasIndex(e => e.Id, "IX_Alumni_ThongTinTruong").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DiaChi).HasMaxLength(500);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Logo)
                .IsUnicode(false)
                .HasComment("lưu đường dẫn của hình logo");
            entity.Property(e => e.MaTruong)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenTruong).HasMaxLength(500);
        });

        modelBuilder.Entity<AlumniThuTuc>(entity =>
        {
            entity.ToTable("Alumni_ThuTuc");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CuuSvId).HasColumnName("CuuSV_Id");
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.DonViNhanYeuCau).HasMaxLength(1000);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MaLinhVuc).HasMaxLength(100);
            entity.Property(e => e.MaLoaiHoSo).HasMaxLength(50);
            entity.Property(e => e.MaThuTuc).HasMaxLength(1000);
            entity.Property(e => e.NgayNhanKetQua).HasColumnType("datetime");
            entity.Property(e => e.NgayYeuCau).HasColumnType("datetime");
            entity.Property(e => e.NguoiTraKetQua).HasMaxLength(1000);
            entity.Property(e => e.TrangThai).HasComment("Trạng thái: \r\n1 - Mới , \r\n2 - Đang chờ kết quả, \r\n3 - Đã nhận kết quả, \r\n4 - Hủy yêu cầu, \r\n5 - Từ chối");

            entity.HasOne(d => d.CuuSv).WithMany(p => p.AlumniThuTucs)
                .HasForeignKey(d => d.CuuSvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_ThuTuc_Alumni_CuuSV");
        });

        modelBuilder.Entity<AlumniVanBang>(entity =>
        {
            entity.ToTable("Alumni_VanBang");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CuuSvId).HasColumnName("CuuSV_Id");
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.NgayNhanVanBang).HasColumnType("datetime");
            entity.Property(e => e.NguoiCapVanBang).HasMaxLength(255);
            entity.Property(e => e.NoiCapVanBang).HasMaxLength(500);
            entity.Property(e => e.QuyetDinh).HasMaxLength(50);
            entity.Property(e => e.SoChungChi).HasMaxLength(50);
            entity.Property(e => e.ThongTinDaoTaoId).HasColumnName("ThongTinDaoTao_Id");

            entity.HasOne(d => d.ThongTinDaoTao).WithMany(p => p.AlumniVanBangs)
                .HasForeignKey(d => d.ThongTinDaoTaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_VanBang_Alumni_ThongTinDaoTao");
        });

        modelBuilder.Entity<AlumniViecLam>(entity =>
        {
            entity.ToTable("Alumni_ViecLam", tb => tb.HasComment("\"01\" - Thi tuyển\r\n\"02\" - Xét tuyển\r\n\"03\" - Hợp đồng\r\n\"04\" - Biệt phái\r\n\"05\" - Điều động\r\n"));

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CuuSvId).HasColumnName("CuuSV_Id");
            entity.Property(e => e.Deleted).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(255);
            entity.Property(e => e.HinhThucTuyenDung)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Thực tập\r\nBán thời gian\r\nToàn thời gian");
            entity.Property(e => e.KinhNghiemLamViec).HasComment("mô tả kinh nghiệm làm việc");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MucLuongKhoiDiem).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ThoiGianLamViec).HasMaxLength(255);
            entity.Property(e => e.ViTriViecLam)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CuuSv).WithMany(p => p.AlumniViecLams)
                .HasForeignKey(d => d.CuuSvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Alumni_ViecLam_Alumni_CuuSV");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
