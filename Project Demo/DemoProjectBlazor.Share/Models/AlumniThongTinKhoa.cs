using System;
using System.Collections.Generic;

namespace DemoProject.Server.Models;

public partial class AlumniThongTinKhoa
{
    public Guid Id { get; set; }

    public string MaKhoa { get; set; } = null!;

    public string TenKhoa { get; set; } = null!;

    public Guid? TruongId { get; set; }

    public DateTime? Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? Deleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<AlumniThongTinSuKien> AlumniThongTinSuKiens { get; set; } = new List<AlumniThongTinSuKien>();

    public virtual AlumniThongTinTruong? Truong { get; set; }
}
