using System;
using System.Collections.Generic;
using System.Linq;

namespace KinKubKai.Models
{
    public class OrderItem
    {
        public int Id { get; set; }           // 📌 Primary Key ของรายการนี้
        public int OrderId { get; set; }      // 📌 Foreign Key เชื่อมไปตาราง Order

        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal => Price * Quantity;
        public string Status { get; set; } = "Cooking"; // Cooking -> Served
    }

    public class Order
    {
        public int Id { get; set; }           // 📌 Primary Key ของออเดอร์
        public int TableNumber { get; set; }

        // 📌 EF Core จะใช้ List นี้สร้างความสัมพันธ์แบบ One-to-Many โดยอัตโนมัติ
        public List<OrderItem> Items { get; set; } = new();

        public decimal Total => Items.Sum(i => i.Subtotal);
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "รอครัวรับ"; // รอครัวรับ -> กำลังทำ -> เสิร์ฟแล้ว
    }
}