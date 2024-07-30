using EFtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFtest.Controllers
{
    public class KhoaController : Controller
    {
        // GET: Khoa
        EFtestEntities dataTest = new EFtestEntities();
        // Lấy danh sách Khoa
        public ActionResult Index()
        {
            return View(dataTest.Khoas.ToList());
        }
        
        // Thêm Khoa
        public ActionResult Create()
        {
            return View();
        }
        // Thêm Khoa từ Database
        [HttpPost]
        public ActionResult Create(Khoa kh)
        {
            try
            {
                dataTest.Khoas.Add(kh);
                dataTest.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // Hiện thông tin Khoa khi ấn edit
        public ActionResult Edit(string id)
        {
            Khoa kh = dataTest.Khoas.Find(id);
            if (kh == null)
            {
                return HttpNotFound();
            }

            return View(kh);
        }
        // Cập nhật dữ liệu từ database
        [HttpPost]
        public ActionResult Edit(Khoa k)
        {
            try
            {
                Khoa kh = dataTest.Khoas.Find(k.makhoa);
                kh.tenkhoa = k.tenkhoa;
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
            Khoa sv = dataTest.Khoas.Find(id);
            if (sv == null)
            {
                return HttpNotFound();
            }
            return View(sv);
        }
        //Lấy dữ liệu của người dùng để xóa
        //public ActionResult Delete(string id)
        //{
        //    SinhVien sv = dataTest.SinhViens.Find(id);
        //    if (sv == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sv);
        //}
        //Xóa người dùng từ DB
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                Khoa kh = dataTest.Khoas.Find(id);
                dataTest.Khoas.Remove(kh);
                dataTest.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}