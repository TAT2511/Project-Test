using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoProjectBlazor.Server.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoProjectBlazor.Controllers
{
	[Route("api/cuuSinhVien")]
	[ApiController]
	public class CuuSinhVienController : Controller
	{
		private readonly DemoProjectBlazorDBContext dataSinhVien;

		public CuuSinhVienController(DemoProjectBlazorDBContext data)
		{
			dataSinhVien = data;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<AlumniCuuSv>>> Index()
		{
			return await dataSinhVien.AlumniCuuSvs.ToListAsync();
		}
		public Task<ActionResult<IEnumerable<AlumniCuuSv>>> Index(int? page)
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

			return Task.FromResult<ActionResult<IEnumerable<AlumniCuuSv>>>(View());
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAlumni(Guid id)
		{
			var cuuSV = await dataSinhVien.AlumniCuuSvs.FindAsync(id);
			if (cuuSV == null)
			{
				return NotFound();
			}

			dataSinhVien.AlumniCuuSvs.Remove(cuuSV);
			await dataSinhVien.SaveChangesAsync();

			return NoContent();
		}

		public ActionResult Create()
		{
			// Lấy danh sách Tỉnh/Thành phố và truyền vào ViewBag
			var danhSachTinh = dataSinhVien.AlumniDonViHanhChinhs.Where(d => d.LoaiDonViHanhChinhId == new Guid("272B1F7D-3574-420C-AF0D-573379FE51AC"))
				.Select(d => new
				{
					TenDonViHanhChinh = d.TenDonViHanhChinh,
					ID = d.Id
				})
				.ToList();
			ViewBag.DanhSachTinh = new SelectList(danhSachTinh, "ID", "TenDonViHanhChinh");

			// Lấy danh sách Quận/Huyện và truyền vào ViewBag
			var danhSachQuanHuyen = dataSinhVien.AlumniDonViHanhChinhs.Where(d => d.LoaiDonViHanhChinhId == new Guid("68AEA74D-AA3D-4016-93B5-BE8B6F6AA4FC"))
				.Select(d => new
				{
					TenDonViHanhChinh = d.TenDonViHanhChinh,
					ID = d.Id
				})
				.ToList();
			ViewBag.DanhSachQuanHuyen = new SelectList(danhSachQuanHuyen, "ID", "TenDonViHanhChinh");

			// Lấy danh sách Xã/Phường và truyền vào ViewBag
			var danhSachXaPhuong = dataSinhVien.AlumniDonViHanhChinhs.Where(d => d.LoaiDonViHanhChinhId == new Guid("99E34B70-B36B-49B1-A98C-CE417079A148"))
				.Select(d => new
				{
					TenDonViHanhChinh = d.TenDonViHanhChinh,
					ID = d.Id
				})
				.ToList();
			ViewBag.DanhSachXaPhuong = new SelectList(danhSachXaPhuong, "ID", "TenDonViHanhChinh");

			// Lấy danh sách TruongIdList từ ViewBag và giá trị MaTruong từ Alumni_ThongTinTruong
			List<AlumniThongTinTruong> truongIdList = dataSinhVien.AlumniThongTinTruongs.ToList();
			ViewBag.TruongIdList = new SelectList(truongIdList, "Id", "TenTruong");

			// Lấy danh sách QuocGiaIdList từ ViewBag và giá trị MaQuocGia từ Alumni_QuocGia
			List<AlumniQuocGium> quocGiaList = dataSinhVien.AlumniQuocGia.ToList();
			ViewBag.QuocGiaIdList = new SelectList(quocGiaList, "ID", "TenQuocGia");

			return View();
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

					dataSinhVien.AlumniCuuSvs.Add(sv);
					await dataSinhVien.SaveChangesAsync();

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
			// Lấy danh sách Tỉnh/Thành phố và truyền vào ViewBag
			var danhSachTinh = dataSinhVien.AlumniDonViHanhChinhs.Where(d => d.LoaiDonViHanhChinhId == new Guid("272B1F7D-3574-420C-AF0D-573379FE51AC"))
				.Select(d => new
				{
					TenDonViHanhChinh = d.TenDonViHanhChinh,
					ID = d.Id
				})
				.ToList();
			ViewBag.DanhSachTinh = new SelectList(danhSachTinh, "ID", "TenDonViHanhChinh");

			// Lấy danh sách Quận/Huyện và truyền vào ViewBag
			var danhSachQuanHuyen = dataSinhVien.AlumniDonViHanhChinhs.Where(d => d.LoaiDonViHanhChinhId == new Guid("68AEA74D-AA3D-4016-93B5-BE8B6F6AA4FC"))
				.Select(d => new
				{
					TenDonViHanhChinh = d.TenDonViHanhChinh,
					ID = d.Id
				})
				.ToList();
			ViewBag.DanhSachQuanHuyen = new SelectList(danhSachQuanHuyen, "ID", "TenDonViHanhChinh");

			// Lấy danh sách Xã/Phường và truyền vào ViewBag
			var danhSachXaPhuong = dataSinhVien.AlumniDonViHanhChinhs.Where(d => d.LoaiDonViHanhChinhId == new Guid("99E34B70-B36B-49B1-A98C-CE417079A148"))
				.Select(d => new
				{
					TenDonViHanhChinh = d.TenDonViHanhChinh,
					ID = d.Id
				})
				.ToList();
			ViewBag.DanhSachXaPhuong = new SelectList(danhSachXaPhuong, "ID", "TenDonViHanhChinh");

			// Lấy danh sách TruongIdList từ ViewBag và giá trị MaTruong từ Alumni_ThongTinTruong
			List<AlumniThongTinTruong> truongIdList = dataSinhVien.AlumniThongTinTruongs.ToList();
			ViewBag.TruongIdList = new SelectList(truongIdList, "Id", "TenTruong");

			// Lấy danh sách QuocGiaIdList từ ViewBag và giá trị MaQuocGia từ Alumni_QuocGia
			List<AlumniQuocGium> quocGiaList = dataSinhVien.AlumniQuocGia.ToList();
			ViewBag.QuocGiaIdList = new SelectList(quocGiaList, "ID", "TenQuocGia");

			var alumni_CuuSV = dataSinhVien.AlumniCuuSvs.Include(s => s.AlumniThongTinDaoTaos).Include(s => s.AlumniQuyetDinhDaoTaos).FirstOrDefault(s => s.Id == id);
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
				dataSinhVien.Entry(cuuSV).State = EntityState.Modified;
				await dataSinhVien.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			return BadRequest(ModelState); // Trả về thông báo lỗi nếu dữ liệu không hợp lệ
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
