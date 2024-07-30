using EFtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EFtest.Controllers
{
    public class SinhVienController : Controller
    {
        EFtestEntities dataTest = new EFtestEntities();
        // GET: SinhVien
        // Lấy danh sách sinh viên
        public ActionResult Index()
        {
            var sinhViens = dataTest.SinhViens.Include("Khoa").ToList();
            var khoaList = dataTest.Khoas.ToList();

            ViewBag.SinhViens = sinhViens;
            ViewBag.KhoaList = khoaList;
            return View(sinhViens);
        }
        // Thêm sinh viên
        public ActionResult Create()
        {
            List<Khoa> khoaList = dataTest.Khoas.ToList();
            ViewBag.KhoaList = new SelectList(khoaList, "makhoa", "tenkhoa");
            return View();
        }
        // Thêm sinh viên từ Database
        [HttpPost]
        public ActionResult Create(SinhVien sv)
        {
            try
            {
                dataTest.SinhViens.Add(sv);
                dataTest.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // Hiện thông tin sinh viên khi ấn edit
        public ActionResult Edit(string id)
        {
            SinhVien sv = dataTest.SinhViens.Find(id);
            if (sv == null)
            {
                return HttpNotFound();
            }

            List<Khoa> khoaList = dataTest.Khoas.ToList();
            ViewBag.KhoaList = new SelectList(khoaList, "makhoa", "tenkhoa", sv.makhoa);

            return View(sv);
        }
        // Cập nhật dữ liệu từ database
        [HttpPost]
        public ActionResult Edit(SinhVien sV)
        {
            try
            {
                SinhVien sv = dataTest.SinhViens.Find(sV.masv);
                sv.tensv = sV.tensv;
                sv.makhoa = sV.makhoa;
                dataTest.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(string id)
        {
            SinhVien sv = dataTest.SinhViens.Find(id);
            if (sv == null)
            {
                return HttpNotFound();
            }
            return View(sv);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                SinhVien sv = dataTest.SinhViens.Find(id);
                dataTest.SinhViens.Remove(sv);
                dataTest.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //Xóa trong từng mục checkbox
        [HttpPost]
        public ActionResult DeleteSelectedItems(List<string> ids)
        {
            foreach (var id in ids)
            {
                SinhVien sv = dataTest.SinhViens.Find(id);
                if (sv != null)
                {
                    dataTest.SinhViens.Remove(sv);
                }
            }

            dataTest.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Search(string keyword)
        {
            var searchResults = dataTest.SinhViens.Where(s => s.tensv.Contains(keyword)).ToList();

            return View("Index", searchResults);
        }

        [HttpGet]
        public ActionResult Filter(string makhoa, string searchQuery)
        {
            var sinhViens = dataTest.SinhViens.Include("Khoa").ToList();

            // Lọc theo mã khoa
            if (!string.IsNullOrEmpty(makhoa))
            {
                sinhViens = sinhViens.Where(s => s.Khoa.makhoa == makhoa).ToList();
            }

            // Tìm kiếm theo query
            if (!string.IsNullOrEmpty(searchQuery))
            {
                sinhViens = sinhViens.Where(s => s.tensv.ToLower().Contains(searchQuery.ToLower())).ToList();
            }

            ViewBag.SinhViens = sinhViens;
            ViewBag.KhoaList = dataTest.Khoas.ToList();
            ViewBag.SelectedKhoa = makhoa; // Lưu mã khoa được chọn để hiển thị lại trên dropdown sau khi lọc

            return View("Index");
        }
    }
}