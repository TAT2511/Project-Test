using DemoProject.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DemoProject.Controllers
{
    public class CuuSinhVienController : Controller
    {
        PSC_AlumniEntities dataSinhVien = new PSC_AlumniEntities();
        // GET: CuuSinhVien
        public ActionResult Index(int? page)
        {
            int pageSize = 5; // Số lượng phần tử trên mỗi trang
            int pageNumber = page ?? 1;

            var CuuSV = dataSinhVien.Alumni_CuuSV.Include("Alumni_ThongTinDaoTao").Include("Alumni_QuyetDinhDaoTao").ToList();
            var thongTinDaoTaoList = dataSinhVien.Alumni_ThongTinDaoTao.ToList();

            int totalItems = CuuSV.Count();

            // Tính toán số trang và giới hạn trang hiện tại
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            pageNumber = Math.Max(1, Math.Min(pageNumber, totalPages));

            var pagedSinhViens = CuuSV.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.SinhViens = pagedSinhViens;
            ViewBag.ThongTinDaoTaoList = thongTinDaoTaoList;
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalItems = totalItems;
            ViewBag.PageSize = pageSize;

            return View();
        }

        // GET: CuuSinhVien/Details/5

        public ActionResult Details(Guid id)
        {
            Alumni_CuuSV alumni_CuuSV = dataSinhVien.Alumni_CuuSV.Include("Alumni_ThongTinDaoTao").Include("Alumni_QuyetDinhDaoTao").FirstOrDefault(s => s.Id == id);

            if (alumni_CuuSV == null)
            {
                return HttpNotFound();
            }
            return View(alumni_CuuSV);
        }

        // GET: CuuSinhVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CuuSinhVien/Create
        [HttpPost]
        public ActionResult Create(Alumni_CuuSV sv)
        {
            if (ModelState.IsValid)
            {
                string randomGuid = null;

                bool isDuplicateId = true;

                while (isDuplicateId)
                {
                    randomGuid = GuidGenerator.GenerateRandomGuid();
                    isDuplicateId = dataSinhVien.Alumni_CuuSV.Any(s => s.Id == new Guid(randomGuid));
                }

                sv.Id = new Guid(randomGuid);
                dataSinhVien.Alumni_CuuSV.Add(sv);
                dataSinhVien.SaveChanges();
                return RedirectToAction("Index");
            }

            // Nếu có lỗi validation, hiển thị các thông báo lỗi
            foreach (var modelStateValue in ModelState.Values)
            {
                foreach (var error in modelStateValue.Errors)
                {
                    // Xử lý lỗi validation
                    ModelState.AddModelError("", error.ErrorMessage);
                }
            }

            return View(sv);
        }

        // GET: CuuSinhVien/Edit/5
        public ActionResult Edit(Guid id)
        {
            Alumni_CuuSV alumni_CuuSV = dataSinhVien.Alumni_CuuSV.Include("Alumni_ThongTinDaoTao").Include("Alumni_QuyetDinhDaoTao").FirstOrDefault(s => s.Id == id);
            //var alumni_CuuSV = dataSinhVien.Alumni_CuuSV.Find(id);
            if (alumni_CuuSV == null)
            {
                return HttpNotFound();
            }
            return View(alumni_CuuSV);
        }

        // POST: CuuSinhVien/Edit/5
        [HttpPost]
        public ActionResult Edit(Alumni_CuuSV cuuSV)
        {
            if (ModelState.IsValid)
            {
                dataSinhVien.Entry(cuuSV).State = EntityState.Modified;
                dataSinhVien.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cuuSV);

        }

        // POST: CuuSinhVien/Delete/5 
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var cuuSV = dataSinhVien.Alumni_CuuSV.Find(id);
            if (cuuSV == null)
            {
                return HttpNotFound();
            }
            dataSinhVien.Alumni_CuuSV.Remove(cuuSV);
            dataSinhVien.SaveChanges();
            return RedirectToAction("Index");
        }
        //Xóa trong từng mục checkbox
        [HttpPost]
        public ActionResult DeleteSelectedItems(List<string> ids)
        {
            foreach (var id in ids)
            {
                Guid itemId;
                if (Guid.TryParse(id, out itemId))
                {
                    var cuuSV = dataSinhVien.Alumni_CuuSV.Find(itemId);
                    if (cuuSV != null)
                    {
                        dataSinhVien.Alumni_CuuSV.Remove(cuuSV);
                    }
                }
            }

            dataSinhVien.SaveChanges();
            return RedirectToAction("Index");
        }
        //Tìm kiếm sinh viên với lọc danh sách sinh viên
        [HttpGet]
        public ActionResult Filter(string tenNganhHoc, string tenKhoaHoc, string tenNienKhoa, string searchQuery)
        {
            var sinhViens = dataSinhVien.Alumni_CuuSV.Include("Alumni_ThongTinDaoTao").Include("Alumni_QuyetDinhDaoTao").ToList();

            // Lọc theo tên ngành học
            if (!string.IsNullOrEmpty(tenNganhHoc))
            {
                sinhViens = sinhViens.Where(s => s.Alumni_ThongTinDaoTao.Any(t => t.TenNganhHoc == tenNganhHoc)).ToList();
            }

            // Lọc theo tên khóa học
            if (!string.IsNullOrEmpty(tenKhoaHoc))
            {
                sinhViens = sinhViens.Where(s => s.Alumni_ThongTinDaoTao.Any(t => t.TenKhoaHoc == tenKhoaHoc)).ToList();
            }
            
            // Lọc theo tên niên khóa
            if (!string.IsNullOrEmpty(tenNienKhoa))
            {
                sinhViens = sinhViens.Where(s => s.Alumni_ThongTinDaoTao.Any(t => t.NienKhoa == tenNienKhoa)).ToList();
            }

            // Tìm kiếm theo query
            if (!string.IsNullOrEmpty(searchQuery))
            {
                sinhViens = sinhViens.Where(s => s.HoTen_CuuSV.ToLower().Contains(searchQuery.ToLower())).ToList();
            }
            
            ViewBag.SelectedNganhHoc = tenNganhHoc;
            ViewBag.SelectedKhoaHoc = tenKhoaHoc;
            ViewBag.SelectedNienKhoa = tenNienKhoa;

            ViewBag.ThongTinDaoTaoList = dataSinhVien.Alumni_ThongTinDaoTao.ToList();
            ViewBag.SinhViens = sinhViens;
            return View("Index");
        }
    }
}

//Hàm tạo id ngẫu nhiên
public static class GuidGenerator
{
    public static string GenerateRandomGuid()
    {
        return Guid.NewGuid().ToString();
    }
}
