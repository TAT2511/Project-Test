using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoProjectBlazor.Server.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DemoProjectBlazor.Client.Pages.Create;
using Microsoft.IdentityModel.Tokens;
using MvcSelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;

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

		//Lấy mã sinh viên
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var student = await _context.AlumniCuuSvs.FindAsync(id);
			if (student == null)
			{
				return NotFound();
			}
			return Ok(student);
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
		// Phương thức chỉnh sửa thông tin sinh viên
		[HttpPut("{id}")]
		public async Task<IActionResult> Edit(Guid id, [FromBody] AlumniCuuSv updatedSv)
		{
			if (id != updatedSv.Id)
			{
				return BadRequest("ID không khớp.");
			}

			if (ModelState.IsValid)
			{
				try
				{
					// Cập nhật dữ liệu sinh viên
					_context.Entry(updatedSv).State = EntityState.Modified;
					await _context.SaveChangesAsync();

					return Ok(updatedSv);
				}
				catch (Exception ex)
				{
					return BadRequest(ex.Message);
				}
			}

			return BadRequest(ModelState);
		}
		[HttpGet("dataCuuSV")]
		public async Task<IActionResult> GetDataCuuSV()
		{
			// Truy vấn danh sách quốc gia
			var quocGiaList = await _context.AlumniQuocGia
				.Select(q => new MvcSelectListItem
				{
					Value = q.Id.ToString(),
					Text = q.TenQuocGia
				})
				.ToListAsync();

			// Truy vấn danh sách trường học
			var truongHocList = await _context.AlumniThongTinTruongs
				.Select(t => new MvcSelectListItem
				{
					Value = t.Id.ToString(),
					Text = t.TenTruong
				})
				.ToListAsync();

			// Truy vấn danh sách tỉnh/thành
			var tinhThanhList = await _context.AlumniDonViHanhChinhs
				.Where(d => d.LoaiDonViHanhChinhId == new Guid("272B1F7D-3574-420C-AF0D-573379FE51AC"))
				.Select(d => new MvcSelectListItem
				{
					Value = d.Id.ToString(),
					Text = d.TenDonViHanhChinh
				})
				.ToListAsync();

			// Truy vấn danh sách quận/huyện
			var quanHuyenList = await _context.AlumniDonViHanhChinhs
					.Where(d => d.LoaiDonViHanhChinhId == new Guid("68AEA74D-AA3D-4016-93B5-BE8B6F6AA4FC"))
					.Select(d => new MvcSelectListItem
					{
						Value = d.Id.ToString(),
						Text = d.TenDonViHanhChinh
					})
					.ToListAsync();
			// Truy vấn danh sách phường/xã 
			var phuongXaList = await _context.AlumniDonViHanhChinhs
					.Where(d => d.LoaiDonViHanhChinhId == new Guid("99E34B70-B36B-49B1-A98C-CE417079A148"))
					.Select(d => new MvcSelectListItem
					{
						Value = d.Id.ToString(),
						Text = d.TenDonViHanhChinh
					})
					.ToListAsync();

			// Tạo đối tượng kết quả và trả về dưới dạng JSON
			var result = new
			{
				QuocGias = quocGiaList,
				Truongs = truongHocList,
				TinhThanhs = tinhThanhList,
				QuanHuyens = quanHuyenList,
				PhuongXas = phuongXaList
			};

			return Ok(result);
		}
		[HttpGet("Filter")]
		public async Task<IActionResult> Filter([FromQuery] string? sex, [FromQuery] string? searchQuery, [FromQuery] int page = 1, [FromQuery] int pageSize = 5)
		{
			// Giả sử bạn có một phương thức để lấy dữ liệu và tổng số mục
			var query = _context.AlumniCuuSv.AsQueryable();

			if (!string.IsNullOrEmpty(sex))
			{
				query = query.Where(sv => sv.Gender == sex);
			}

			if (!string.IsNullOrEmpty(searchQuery))
			{
				query = query.Where(sv => sv.Name.Contains(searchQuery));
			}

			var totalCount = await query.CountAsync();
			var data = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

			var response = new FilterResponse
			{
				Data = data,
				TotalCount = totalCount
			};

			return Ok(response);
		}
		public class FilterResponse
		{
			public List<AlumniCuuSv> Data { get; set; }
			public int TotalCount { get; set; }
		}
	}
}
