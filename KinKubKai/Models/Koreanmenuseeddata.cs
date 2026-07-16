using System.Collections.Generic;
using KinKubKai.Models;

namespace KinKubKai.Data
{
    // 📌 ข้อมูลเมนูที่ดึงมาจากภาพเมนูเกาหลี
    // ⚠️ ช่อง ImageUrl เป็น path ตัวอย่าง (placeholder) เท่านั้น
    //    กรุณาแก้ให้ตรงกับรูปจริงที่จะอัปโหลดไว้ใน wwwroot/image/menu/
    public static class KoreanMenuSeedData
    {
        public static List<MenuItem> GetItems()
        {
            return new List<MenuItem>
            {
                // ---------- เมนูเกาหลี ----------
                new MenuItem { Name = "คิมบับ (ข้าวห่อสาหร่าย เลือกไส้ 1 อย่าง)", Category = "เมนูเกาหลี", Price = 60, ImageUrl = "/image/menu/kimbap.jpg" },
                new MenuItem { Name = "คิมมาริ", Category = "เมนูเกาหลี", Price = 60, ImageUrl = "/image/menu/kimmari.jpg" },
                new MenuItem { Name = "จังแช (ยำวุ้นเส้นแบบเกาหลี)", Category = "เมนูเกาหลี", Price = 60, ImageUrl = "/image/menu/japchae.jpg" },
                new MenuItem { Name = "ต๊อกบกกี", Category = "เมนูเกาหลี", Price = 65, ImageUrl = "/image/menu/tteokbokki.jpg" },
                new MenuItem { Name = "รากกี", Category = "เมนูเกาหลี", Price = 75, ImageUrl = "/image/menu/ragki.jpg" },
                new MenuItem { Name = "ซุปกิมจิ (กันจังจิเก)", Category = "เมนูเกาหลี", Price = 60, ImageUrl = "/image/menu/kimchi-soup.jpg" },
                new MenuItem { Name = "เกนจังจิเก", Category = "เมนูเกาหลี", Price = 60, ImageUrl = "/image/menu/doenjang-jjigae.jpg" },
                new MenuItem { Name = "ซุปสาหร่าย", Category = "เมนูเกาหลี", Price = 60, ImageUrl = "/image/menu/seaweed-soup.jpg" },
                new MenuItem { Name = "ข้าวผัดกิมจิใส่ไข่ดาว", Category = "เมนูเกาหลี", Price = 60, ImageUrl = "/image/menu/kimchi-fried-rice.jpg" },
                new MenuItem { Name = "บิบิมบับ", Category = "เมนูเกาหลี", Price = 65, ImageUrl = "/image/menu/bibimbap.jpg" },
                new MenuItem { Name = "จาจังยอน", Category = "เมนูเกาหลี", Price = 60, ImageUrl = "/image/menu/jajangmyeon.jpg" },
                new MenuItem { Name = "รามยอนไข่ลวก (เผ็ดน้อย/ปาน)", Category = "เมนูเกาหลี", Price = 60, ImageUrl = "/image/menu/ramyeon-egg.jpg" },
                new MenuItem { Name = "รามยอนไข่ลวก เผ็ด x2", Category = "เมนูเกาหลี", Price = 65, ImageUrl = "/image/menu/ramyeon-spicy2.jpg" },
                new MenuItem { Name = "รามยอนเกาหลี", Category = "เมนูเกาหลี", Price = 60, ImageUrl = "/image/menu/ramyeon.jpg" },
                new MenuItem { Name = "รามยอนซุปกระดูก", Category = "เมนูเกาหลี", Price = 70, ImageUrl = "/image/menu/ramyeon-bone-soup.jpg" },

                // ---------- สลัดโบวล์ ----------
                new MenuItem { Name = "สลัดปูอัด", Category = "สลัดโบวล์", Price = 60, ImageUrl = "/image/menu/salad-crab.jpg" },
                new MenuItem { Name = "สลัดไก่กรอบ", Category = "สลัดโบวล์", Price = 60, ImageUrl = "/image/menu/salad-crispy-chicken.jpg" },
                new MenuItem { Name = "สลัดทูน่า", Category = "สลัดโบวล์", Price = 60, ImageUrl = "/image/menu/salad-tuna.jpg" },
                new MenuItem { Name = "แรพโรล", Category = "สลัดโบวล์", Price = 60, ImageUrl = "/image/menu/wrap-roll.jpg" },
            };
        }
    }
}