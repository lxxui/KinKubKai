using System.Collections.Generic;
using System.Linq;
using KinKubKai.Models;

namespace KinKubKai.Data
{
    // 📌 เก็บออเดอร์ไว้ในหน่วยความจำชั่วคราว (ยังไม่ต่อฐานข้อมูลจริง)
    //    ⚠️ ถ้า restart แอป ออเดอร์ทั้งหมดจะหายไป — เหมาะแค่สำหรับทดสอบ
    //    เมื่อพร้อมต่อ DB จริง ค่อยเปลี่ยนไปบันทึกผ่าน AppDbContext แทน
    public static class OrderStore
    {
        private static readonly List<Order> _orders = new();
        private static readonly object _lock = new();
        private static int _nextId = 1;

        public static Order AddOrder(int tableNumber, List<OrderItem> items)
        {
            lock (_lock)
            {
                var order = new Order
                {
                    Id = _nextId++,
                    TableNumber = tableNumber,
                    Items = items
                };
                _orders.Add(order);
                return order;
            }
        }

        // ออเดอร์ที่ยังไม่เสิร์ฟ เรียงจากเก่าสุดไปใหม่สุด (ครัวควรทำอันเก่าก่อน)
        public static List<Order> GetActiveOrders()
        {
            lock (_lock)
            {
                return _orders
                    .Where(o => o.Status != "เสิร์ฟแล้ว")
                    .OrderBy(o => o.CreatedAt)
                    .ToList();
            }
        }

        public static void UpdateStatus(int orderId, string status)
        {
            lock (_lock)
            {
                var order = _orders.FirstOrDefault(o => o.Id == orderId);
                if (order != null) order.Status = status;
            }
        }
    }
}
