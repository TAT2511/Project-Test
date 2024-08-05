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
            var CuuSV = dataSinhVien.Alumni_CuuSV.Include("Alumni_ThongTinDaoTao").Include("Alumni_QuyetDinhDaoTao").ToList();

            int pageSize = 10; // Số lượng phần tử trên mỗi trang
            int pageNumber = page ?? 1;
            int totalItems = CuuSV.Count();

            // Tính toán số trang và giới hạn trang hiện tại
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            pageNumber = Math.Max(1, Math.Min(pageNumber, totalPages));

            var pagedSinhViens = CuuSV.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            //ViewBag thông tin sinh viên
            ViewBag.SinhViens = pagedSinhViens;
            ViewBag.ThongTinDaoTaoList = dataSinhVien.Alumni_ThongTinDaoTao.ToList(); ;
            ViewBag.QuyetDinhDaoTaoList = dataSinhVien.Alumni_QuyetDinhDaoTao.ToList(); ;

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
            // Lấy danh sách Tỉnh/Thành phố và truyền vào ViewBag
            var danhSachTinh = dataSinhVien.Alumni_DonViHanhChinh.Where(d => d.LoaiDonViHanhChinh_Id == new Guid("272B1F7D-3574-420C-AF0D-573379FE51AC"))
                .Select(d => new
                {
                    TenDonViHanhChinh = d.TenDonViHanhChinh,
                    ID = d.ID
                })
                .ToList();
            ViewBag.DanhSachTinh = new SelectList(danhSachTinh, "ID", "TenDonViHanhChinh");

            // Lấy danh sách Quận/Huyện và truyền vào ViewBag
            var danhSachQuanHuyen = dataSinhVien.Alumni_DonViHanhChinh.Where(d => d.LoaiDonViHanhChinh_Id == new Guid("68AEA74D-AA3D-4016-93B5-BE8B6F6AA4FC"))
                .Select(d => new
                {
                    TenDonViHanhChinh = d.TenDonViHanhChinh,
                    ID = d.ID
                })
                .ToList();
            ViewBag.DanhSachQuanHuyen = new SelectList(danhSachQuanHuyen, "ID", "TenDonViHanhChinh");

            // Lấy danh sách Xã/Phường và truyền vào ViewBag
            var danhSachXaPhuong = dataSinhVien.Alumni_DonViHanhChinh.Where(d => d.LoaiDonViHanhChinh_Id == new Guid("99E34B70-B36B-49B1-A98C-CE417079A148"))
                .Select(d => new
                {
                    TenDonViHanhChinh = d.TenDonViHanhChinh,
                    ID = d.ID
                })
                .ToList();
            ViewBag.DanhSachXaPhuong = new SelectList(danhSachXaPhuong, "ID", "TenDonViHanhChinh");

            // Lấy danh sách TruongIdList từ ViewBag và giá trị MaTruong từ Alumni_ThongTinTruong
            List<Alumni_ThongTinTruong> truongIdList = dataSinhVien.Alumni_ThongTinTruong.ToList();
            ViewBag.TruongIdList = new SelectList(truongIdList, "Id", "TenTruong");

            // Lấy danh sách QuocGiaIdList từ ViewBag và giá trị MaQuocGia từ Alumni_QuocGia
            List<Alumni_QuocGia> quocGiaList = dataSinhVien.Alumni_QuocGia.ToList();
            ViewBag.QuocGiaIdList = new SelectList(quocGiaList, "ID", "TenQuocGia");

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

            return View(sv);
        }

        // GET: CuuSinhVien/Edit/5
        public ActionResult Edit(Guid id)
        {
            // Lấy danh sách Tỉnh/Thành phố và truyền vào ViewBag
            var danhSachTinh = dataSinhVien.Alumni_DonViHanhChinh.Where(d => d.LoaiDonViHanhChinh_Id == new Guid("272B1F7D-3574-420C-AF0D-573379FE51AC"))
                .Select(d => new
                {
                    TenDonViHanhChinh = d.TenDonViHanhChinh,
                    ID = d.ID
                })
                .ToList();
            ViewBag.DanhSachTinh = new SelectList(danhSachTinh, "ID", "TenDonViHanhChinh");

            // Lấy danh sách Quận/Huyện và truyền vào ViewBag
            var danhSachQuanHuyen = dataSinhVien.Alumni_DonViHanhChinh.Where(d => d.LoaiDonViHanhChinh_Id == new Guid("68AEA74D-AA3D-4016-93B5-BE8B6F6AA4FC"))
                .Select(d => new
                {
                    TenDonViHanhChinh = d.TenDonViHanhChinh,
                    ID = d.ID
                })
                .ToList();
            ViewBag.DanhSachQuanHuyen = new SelectList(danhSachQuanHuyen, "ID", "TenDonViHanhChinh");

            // Lấy danh sách Xã/Phường và truyền vào ViewBag
            var danhSachXaPhuong = dataSinhVien.Alumni_DonViHanhChinh.Where(d => d.LoaiDonViHanhChinh_Id == new Guid("99E34B70-B36B-49B1-A98C-CE417079A148"))
                .Select(d => new
                {
                    TenDonViHanhChinh = d.TenDonViHanhChinh,
                    ID = d.ID
                })
                .ToList();
            ViewBag.DanhSachXaPhuong = new SelectList(danhSachXaPhuong, "ID", "TenDonViHanhChinh");

            // Lấy danh sách TruongIdList từ ViewBag và giá trị MaTruong từ Alumni_ThongTinTruong
            List<Alumni_ThongTinTruong> truongIdList = dataSinhVien.Alumni_ThongTinTruong.ToList();
            ViewBag.TruongIdList = new SelectList(truongIdList, "Id", "TenTruong");

            // Lấy danh sách QuocGiaIdList từ ViewBag và giá trị MaQuocGia từ Alumni_QuocGia
            List<Alumni_QuocGia> quocGiaList = dataSinhVien.Alumni_QuocGia.ToList();
            ViewBag.QuocGiaIdList = new SelectList(quocGiaList, "ID", "TenQuocGia");

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
        public ActionResult Filter(string tenNganhHoc, string tenKhoaHoc, string tenNienKhoa, string loaiQuyetDinh, string namHoc, string sex, string searchQuery,int? page)
        {
            var sinhViens = dataSinhVien.Alumni_CuuSV.Include("Alumni_ThongTinDaoTao").Include("Alumni_QuyetDinhDaoTao").ToList();

            // Lọc theo tên ngành học
            if (!string.IsNullOrEmpty(tenNganhHoc))
            {
                sinhViens = sinhViens.Where(s => s.Alumni_ThongTinDaoTao.Select(t => t.TenNganhHoc).Distinct().Contains(tenNganhHoc)).ToList();
            }

            // Lọc theo tên khóa học
            if (!string.IsNullOrEmpty(tenKhoaHoc))
            {
                sinhViens = sinhViens.Where(s => s.Alumni_ThongTinDaoTao.Select(t => t.TenKhoaHoc).Distinct().Contains(tenKhoaHoc)).ToList();
            }

            // Lọc theo tên niên khóa
            if (!string.IsNullOrEmpty(tenNienKhoa))
            {
                sinhViens = sinhViens.Where(s => s.Alumni_ThongTinDaoTao.Select(t => t.NienKhoa).Distinct().Contains(tenNienKhoa)).ToList();
            }

            // Lọc theo tên loại quyết định
            if (!string.IsNullOrEmpty(loaiQuyetDinh))
            {
                sinhViens = sinhViens.Where(s => s.Alumni_QuyetDinhDaoTao.Select(t => t.LoaiQuyetDinh).Distinct().Contains(loaiQuyetDinh)).ToList();
            }

            // Lọc theo năm học
            if (!string.IsNullOrEmpty(namHoc))
            {
                sinhViens = sinhViens.Where(s => s.Alumni_QuyetDinhDaoTao.Select(t => t.NamHoc).Distinct().Contains(namHoc)).ToList();
            }

            // Lọc theo giới tính
            if (!string.IsNullOrEmpty(sex))
            {
                sinhViens = sinhViens.Where(s => s.GioiTinh == sex).ToList();
            }

            // Tìm kiếm theo query
            if (!string.IsNullOrEmpty(searchQuery))
            {
                sinhViens = sinhViens.Where(s => s.HoTen_CuuSV.ToLower().Contains(searchQuery.ToLower())).ToList();
            }

            // Truyền các tham số lọc vào ViewBag hoặc Model để sử dụng trong View
            ViewBag.SelectedNganhHoc = tenNganhHoc;
            ViewBag.SelectedKhoaHoc = tenKhoaHoc;
            ViewBag.SelectedNienKhoa = tenNienKhoa;
            ViewBag.SelectedQuyetDinh = loaiQuyetDinh;
            ViewBag.SelectedNamHoc = namHoc;
            ViewBag.SearchQuery = searchQuery;
            ViewBag.Sex = sex;

            int pageSize = 5; // Số lượng phần tử trên mỗi trang
            int pageNumber = page ?? 1;
            int totalItems = sinhViens.Count();

            // Tính toán số trang và giới hạn trang hiện tại
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            pageNumber = Math.Max(1, Math.Min(pageNumber, totalPages));

            var pagedSinhViens = sinhViens.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            //ViewBag thông tin sinh viên
            ViewBag.SinhViens = pagedSinhViens;

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalItems = totalItems;
            ViewBag.PageSize = pageSize;
            // Truyền dữ liệu đã lọc và phân trang đến View
            ViewBag.ThongTinDaoTaoList = dataSinhVien.Alumni_ThongTinDaoTao.ToList();
            ViewBag.QuyetDinhDaoTaoList = dataSinhVien.Alumni_QuyetDinhDaoTao.ToList();
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
