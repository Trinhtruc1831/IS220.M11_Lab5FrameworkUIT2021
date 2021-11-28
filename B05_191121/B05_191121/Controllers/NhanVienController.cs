using B05_191121.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B05_191121.Controllers
{
    public class NhanVienController : Controller
    {
        public IActionResult LietKeNhanVien()
        {
            return View();
        }
        public IActionResult ListByTime(int solan)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(B05_191121.Models.DataContext)) as DataContext;
            return View(context.sqlListByTimeNhanVien(solan));
        }

        public IActionResult ListNhanVien()
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(B05_191121.Models.DataContext)) as DataContext;
            return View(context.sqlListNhanVien());
        }
        public IActionResult LietKeTB(string MaNhanVien)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(B05_191121.Models.DataContext)) as DataContext;
            return View(context.sqlLietKeTB(MaNhanVien));
        }
        public string Delete(string manv, string matb, string mach, int lt)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(B05_191121.Models.DataContext)) as DataContext;
            if (context.sqlDeleteNVTB(manv, matb, mach, lt) > 0)
                return "Xóa thành công";
            return "Xóa thất bại";
        }

        public IActionResult View(string manv, string matb, string mach, int lt, DateTime nbt)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(B05_191121.Models.DataContext)) as DataContext;
            NVTBModel nvbt = new NVTBModel();
            nvbt.MaNhanVien = manv;
            nvbt.MaThietBi = matb;
            nvbt.MaCanHo = mach;
            nvbt.LanThu = lt;
            nvbt.NgayBaoTri = nbt;
            ViewData.Model = nvbt;
            return View();
        }

        public string Update(string manv, string matb, string mach, int lt, DateTime nbt)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(B05_191121.Models.DataContext)) as DataContext;
            if (context.sqlUpdateNVBT(manv, matb, mach, lt, nbt) > 0)
                return "Cập nhật thành công";
            return "Cập nhật thất bại";
        }
    }
}
