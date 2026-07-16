namespace KinKubKai.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }

        // 1. เพิ่มฟิลด์สำหรับเก็บสถานะอาหาร (Default เป็น "Cooking")
        public string Status { get; set; } = "Cooking";

        // Navigation properties
        public virtual Order? Order { get; set; }
        public virtual MenuItem? MenuItem { get; set; }
    }
}