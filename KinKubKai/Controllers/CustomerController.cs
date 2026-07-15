using KinKubKai.Models;
using Microsoft.AspNetCore.Mvc;

namespace KinKubKai.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            var menuList = new List<MenuItem>
        {
            new MenuItem { Name = "โปรโมชั่น 1", Price = 99, Category = "โปรโมชั่น", ImageUrl = "..." },
            new MenuItem { Name = "ข้าวมันไก่", Price = 50, Category = "ของคาว", ImageUrl = "..." },
            new MenuItem { Name = "เฉาก๊วย", Price = 20, Category = "ของหวาน", ImageUrl = "..." },
            new MenuItem { Name = "น้ำเก๊กฮวย", Price = 15, Category = "น้ำดื่ม", ImageUrl = "..." }
        };
            return View(menuList);
        }
    }
}