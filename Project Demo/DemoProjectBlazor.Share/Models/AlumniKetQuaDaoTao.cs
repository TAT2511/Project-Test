using System;
using System.Collections.Generic;

namespace DemoProject.Server.Models;

public partial class AlumniKetQuaDaoTao
{
    public Guid Id { get; set; }

    public Guid CuuSvId { get; set; }

    public Guid ThongTinDaoTaoId { get; set; }

    public decimal? TcTongSo { get; set; }

    public decimal? TcTichLuy { get; set; }

    public decimal? DiemTbHe10 { get; set; }

    public decimal? DiemTbHe4 { get; set; }

    public decimal? DiemRenLuyen { get; set; }

    /// <summary>
    /// xếp loại dựa trên điểm học tập
    /// </summary>
    public string? XepLoai { get; set; }

    /// <summary>
    /// xếp loại dựa trên điểm rèn luyện
    /// </summary>
    public string? XepLoaiRenLuyen { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<AlumniKetQuaDaoTaoChiTiet> AlumniKetQuaDaoTaoChiTiets { get; set; } = new List<AlumniKetQuaDaoTaoChiTiet>();

    public virtual AlumniThongTinDaoTao ThongTinDaoTao { get; set; } = null!;
}
