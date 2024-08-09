using System;
using System.Collections.Generic;

namespace DemoProjectBlazor.Server.Data;

public partial class AlumniDangKyChiTietSuKien
{
    public Guid? Id { get; set; }

    public Guid? TaiKhoanId { get; set; }

    public Guid? ChiTietSuKienId { get; set; }
}
