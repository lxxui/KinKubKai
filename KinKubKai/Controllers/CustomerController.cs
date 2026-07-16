using KinKubKai.Data;
using KinKubKai.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KinKubKai.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /Customer/Index
        public IActionResult Index(string? table)
        {
            if (!string.IsNullOrEmpty(table))
            {
                HttpContext.Session.SetString("TableNumber", table);
            }
            else if (string.IsNullOrEmpty(HttpContext.Session.GetString("TableNumber")))
            {
                HttpContext.Session.SetString("TableNumber", "9999");
            }

            ViewBag.TableNumber = HttpContext.Session.GetString("TableNumber");

            var menuItems = KoreanMenuSeedData.GetItems()
                .OrderBy(m => m.Category)
                .ThenBy(m => m.Name)
                .ToList();

            return View(menuItems);
        }

        public class CartItemRequest
        {
            public string Name { get; set; } = "";
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }

        // POST: /Customer/PlaceOrder
        [HttpPost]
        public IActionResult PlaceOrder([FromBody] List<CartItemRequest> cartItems)
        {
            var tableNumber = HttpContext.Session.GetString("TableNumber") ?? "9999";

            if (string.IsNullOrEmpty(tableNumber))
            {
                return BadRequest(new { success = false, message = "ไม่พบเลขโต๊ะ กรุณาสแกน QR ที่โต๊ะใหม่อีกครั้ง" });
            }

            if (cartItems == null || !cartItems.Any())
            {
                return BadRequest(new { success = false, message = "ยังไม่ได้เลือกเมนู" });
            }

            // เพิ่มค่าเริ่มต้น Status = "Cooking" ให้กับไอเทมใหม่แต่ละชิ้น
            var items = cartItems.Select(c => new OrderItem
            {
                Name = c.Name,
                Price = c.Price,
                Quantity = c.Quantity,
                Status = "Cooking" // กำหนดค่าเริ่มต้นให้กับออเดอร์ที่เพิ่งส่งเข้าครัว
            }).ToList();

            int numericTable = int.TryParse(tableNumber, out int result) ? result : 99;

            var order = OrderStore.AddOrder(numericTable, items);

            return Json(new { success = true, orderId = order.Id });
        }

        // GET: /Customer/GetTableOrders
        [HttpGet]
        public IActionResult GetTableOrders()
        {
            // 1. ดึงเลขโต๊ะปัจจุบันจาก Session (และจัดการกรณีด่วนแปลงเป็นตัวเลขเหมือนใน PlaceOrder)
            var tableNumber = HttpContext.Session.GetString("TableNumber") ?? "9999";
            int numericTable = int.TryParse(tableNumber, out int result) ? result : 99;

            // 2. ค้นหารายการอาหารทั้งหมดของโต๊ะนี้จากข้อมูลใน OrderStore
            // โดยทำการดึงไอเทมออกมาจากทุกๆ ออเดอร์ที่มาจากโต๊ะเดียวกัน
            var orderItems = OrderStore.GetActiveOrders()
                .Where(o => o.TableNumber == numericTable)
                .SelectMany(o => o.Items)
                .Select(x => new {
                    name = x.Name,
                    qty = x.Quantity,
                    status = !string.IsNullOrEmpty(x.Status) ? x.Status : "Cooking" // หาก Status เป็นค่าว่างให้ Fallback เป็น Cooking
                }).ToList();

            return Json(new { success = true, items = orderItems });
        }
    }
}