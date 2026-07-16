using Microsoft.AspNetCore.Mvc;
using KinKubKai.Data;

namespace KinKubKai.Controllers
{
    public class KitchenController : Controller
    {
        // GET: /Kitchen
        public IActionResult Index()
        {
            var orders = OrderStore.GetActiveOrders();
            return View(orders);
        }

        // POST: /Kitchen/MarkDone/3
        [HttpPost]
        public IActionResult MarkDone(int id)
        {
            OrderStore.UpdateStatus(id, "เสิร์ฟแล้ว");
            return RedirectToAction("Index");
        }
    }
}
