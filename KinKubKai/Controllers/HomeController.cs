using Microsoft.AspNetCore.Mvc;

namespace KinKubKai.Controllers
{
    public class HomeController : Controller
    {
        // หน้าจอหลักของร้าน
        public IActionResult Index()
        {
            return View();
        }

        // เพิ่ม Action นี้สำหรับหน้าสั่งอาหารของลูกค้า
        public IActionResult Order()
        {
            return View(); // จะไปเรียกไฟล์ Order.cshtml
        }
    }
}