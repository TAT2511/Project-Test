using Microsoft.AspNetCore.Mvc;
using DemoProject.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DemoProjectBlazor.Controllers
{
    [Route("api/index")]
    [ApiController]
    public class CuuSinhVienController : Controller
    {
        private readonly DemoProjectDbContext dataSinhVien;

        public CuuSinhVienController(DemoProjectDbContext data)
        {
            dataSinhVien = data;
        }
		[HttpGet]
		public async Task<ActionResult<IEnumerable<AlumniCuuSv>>> Index()
        {
			return await dataSinhVien.AlumniCuuSvs.ToListAsync();
		}
		public async Task<ActionResult<IEnumerable<AlumniCuuSv>>> Index(int? page)
        {
			var CuuSV = dataSinhVien.AlumniCuuSvs.Include("Alumni_ThongTinDaoTao").Include("Alumni_QuyetDinhDaoTao").ToList();

			int pageSize = 5; // Số lượng phần tử trên mỗi trang
			int pageNumber = page ?? 1;
			int totalItems = CuuSV.Count();

			// Tính toán số trang và giới hạn trang hiện tại
			int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
			pageNumber = Math.Max(1, Math.Min(pageNumber, totalPages));

			var pagedSinhViens = CuuSV.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			//ViewBag thông tin sinh viên
			ViewBag.SinhViens = pagedSinhViens;
			ViewBag.ThongTinDaoTaoList = dataSinhVien.AlumniThongTinDaoTaos.ToList(); ;
			ViewBag.QuyetDinhDaoTaoList = dataSinhVien.AlumniQuyetDinhDaoTaos.ToList(); ;

			ViewBag.CurrentPage = pageNumber;
			ViewBag.TotalPages = totalPages;
			ViewBag.TotalItems = totalItems;
			ViewBag.PageSize = pageSize;

			return View();
		}

		[HttpPost]
		[Route("delete/{id}")]
		public async Task<ActionResult> DeleteAlumni(Guid? id)
		{
			var alumni = await dataSinhVien.AlumniCuuSvs.FindAsync(id);
			if (alumni == null)
			{
				return NotFound();
			}
			dataSinhVien.AlumniCuuSvs.Remove(alumni);
			await dataSinhVien.SaveChangesAsync();

			return NoContent(); // Trả về mã trạng thái 204 No Content nếu xóa thành công
		}
	}
}
