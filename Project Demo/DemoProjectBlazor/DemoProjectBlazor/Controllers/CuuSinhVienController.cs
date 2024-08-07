using Microsoft.AspNetCore.Mvc;
using DemoProject.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DemoProjectBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuuSinhVienController : Controller
    {
        private readonly DemoProjectDbContext dataSinhVien;

        public CuuSinhVienController(DemoProjectDbContext data)
        {
            dataSinhVien = data;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<AlumniCuuSv>>> GetAlumni()
        //{
        //    return await dataSinhVien.AlumniCuuSv.ToListAsync();
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
