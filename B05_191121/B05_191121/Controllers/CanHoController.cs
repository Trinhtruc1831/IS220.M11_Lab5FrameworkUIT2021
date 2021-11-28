using B05_191121.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace B05_191121.Controllers
{
    public class CanHoController:Controller
    {
        public IActionResult ThemCanHo()
        {
            return View();
        }
        public string AddCH(CanHoModel canho)
        {
            int count;
            DataContext context = HttpContext.RequestServices.GetService(typeof(B05_191121.Models.DataContext)) as DataContext;
            count = context.sqlInsertCanHo(canho);
            if(count == 1)
            {
                return "Thêm thành công!";
            }
            return "Thêm thất bại!";
        }
        
    }
}
