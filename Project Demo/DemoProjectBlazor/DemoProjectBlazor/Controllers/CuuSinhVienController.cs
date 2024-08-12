using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoProjectBlazor.Server.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DemoProjectBlazor.Client.Pages.Create;
using Microsoft.IdentityModel.Tokens;

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
					sv.Id = Guid.NewGuid(); // Tạo Guid mới cho sv.Id

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
	}
	
}
