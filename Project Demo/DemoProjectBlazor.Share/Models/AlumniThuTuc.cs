using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

public partial class AlumniThuTuc
{
    public Guid Id { get; set; }

    public string MaThuTuc { get; set; } = null!;

    public Guid CuuSvId { get; set; }

    public string TenThuTuc { get; set; } = null!;

    public DateTime? NgayYeuCau { get; set; }

    public string? MaLinhVuc { get; set; }

    public string? TenLinhVuc { get; set; }

    public string? MaLoaiHoSo { get; set; }

    /// <summary>
    /// Trạng thái: 
    /// 1 - Mới , 
    /// 2 - Đang chờ kết quả, 
    /// 3 - Đã nhận kết quả, 
    /// 4 - Hủy yêu cầu, 
    /// 5 - Từ chối
    /// </summary>
    public short? TrangThai { get; set; }

    public string? DonViNhanYeuCau { get; set; }

    public DateTime? NgayNhanKetQua { get; set; }

    public string? NguoiTraKetQua { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual AlumniCuuSv CuuSv { get; set; } = null!;
}
