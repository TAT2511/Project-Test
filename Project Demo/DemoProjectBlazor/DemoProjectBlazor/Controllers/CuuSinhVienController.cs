using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoProjectBlazor.Server.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DemoProjectBlazor.Client.Pages.Create;

namespace DemoProjectBlazor.Controllers
{
	[Route("api/cuuSinhVien")]
	[ApiController]
	public class CuuSinhVienController : Controller
	{
		private readonly DemoProjectBlazorDBContext _context;

		public CuuSinhVienController(DemoProjectBlazorDBContext context)
		{
			_context = context;
		}

		// Phương thức lấy danh sách sinh viên với phân trang
		[HttpGet]
		public async Task<ActionResult<IEnumerable<AlumniCuuSv>>> GetAlumni([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
		{
			var dsCuuSinhVien = await _context.AlumniCuuSvs
											  .Skip((page - 1) * pageSize)
											  .Take(pageSize)
											  .ToListAsync();
			return Ok(dsCuuSinhVien);
		}

		// Phương thức lấy tổng số lượng sinh viên
		[HttpGet("count")]
		public async Task<ActionResult<int>> GetCount()
		{
			var count = await _context.AlumniCuuSvs.CountAsync();
			return Ok(count);
		}

		// Phương thức xóa sinh viên
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAlumni(Guid id)
		{
			var cuuSV = await _context.AlumniCuuSvs.FindAsync(id);
			if (cuuSV == null)
			{
				return NotFound();
			}

			_context.AlumniCuuSvs.Remove(cuuSV);
			await _context.SaveChangesAsync();

			return NoContent();
		}


		// POST: CuuSinhVien/Create
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] AlumniCuuSv sv)
		{
			if (ModelState.IsValid)
			{
				try
				{
					string randomGuid = Guid.NewGuid().ToString();
					sv.Id = new Guid(randomGuid);

					_context.AlumniCuuSvs.Add(sv);
                    await _context.SaveChangesAsync();

                    return Ok(sv); // Trả về dữ liệu sinh viên đã được tạo thành công
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message); // Trả về thông báo lỗi nếu có vấn đề xảy ra
				}
			}

			return BadRequest(ModelState); // Trả về thông báo lỗi nếu dữ liệu không hợp lệ
		}
		public ActionResult Edit(Guid id)
		{
			var alumni_CuuSV = _context.AlumniCuuSvs.Include(s => s.AlumniThongTinDaoTaos).Include(s => s.AlumniQuyetDinhDaoTaos).FirstOrDefault(s => s.Id == id);
			if (alumni_CuuSV == null)
			{
				return NotFound();
			}
			return View(alumni_CuuSV);
		}
		[HttpPost]
		public async Task<IActionResult> Edit([FromBody] AlumniCuuSv cuuSV)
		{
			if (ModelState.IsValid)
			{
				_context.Entry(cuuSV).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			return BadRequest(ModelState); // Trả về thông báo lỗi nếu dữ liệu không hợp lệ
		}
        [HttpGet("danhSachTinh")]
        public ActionResult<IEnumerable<Option>> GetDanhSachTinh()
        {
            var danhSachTinh = _context.AlumniDonViHanhChinhs
                .Where(d => d.LoaiDonViHanhChinhId == new Guid("272B1F7D-3574-420C-AF0D-573379FE51AC"))
                .Select(d => new Option
                {
                    Text = d.TenDonViHanhChinh,
                    Value = d.Id.ToString()
                })
                .ToList();
            return Ok(danhSachTinh);
        }

        [HttpGet("danhSachQuanHuyen")]
        public ActionResult<IEnumerable<Option>> GetDanhSachQuanHuyen()
        {
            var danhSachQuanHuyen = _context.AlumniDonViHanhChinhs
                .Where(d => d.LoaiDonViHanhChinhId == new Guid("68AEA74D-AA3D-4016-93B5-BE8B6F6AA4FC"))
                .Select(d => new Option
				{
                    Text = d.TenDonViHanhChinh,
                    Value = d.Id.ToString()
                })
                .ToList();
            return Ok(danhSachQuanHuyen);
        }
		[HttpGet("danhSachXaPhuong")]
        public ActionResult<IEnumerable<Option>> GetDanhSachXaPhuong()
        {
            var danhSachXaPhuong = _context.AlumniDonViHanhChinhs
                .Where(d => d.LoaiDonViHanhChinhId == new Guid("99E34B70-B36B-49B1-A98C-CE417079A148"))
                .Select(d => new Option
				{
                    Text = d.TenDonViHanhChinh,
                    Value = d.Id.ToString()
                })
                .ToList();
            return Ok(danhSachXaPhuong);
        }
		[HttpGet("danhSachTruong")]
		public ActionResult<IEnumerable<Option>> GetDanhSachTruong()
		{
			var danhSachTruong = _context.AlumniThongTinTruongs
				.Select(t => new Option
				{
					Text = t.TenTruong,
					Value = t.Id.ToString()
				})
				.ToList();

			return Ok(danhSachTruong);
		}
		[HttpGet("danhSachQuocGia")]
		public ActionResult<IEnumerable<Option>> GetDanhSachQuocGia()
		{
			var danhSachQuocGia = _context.AlumniQuocGia
				.Select(t => new Option
				{
					Text = t.TenQuocGia,
					Value = t.Id.ToString()
				})
				.ToList();

			return Ok(danhSachQuocGia);
		}
	}
	public static class GuidGenerator
	{
		public static string GenerateRandomGuid()
		{
			return Guid.NewGuid().ToString();
		}
	}
}
