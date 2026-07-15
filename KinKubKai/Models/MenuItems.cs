namespace KinKubKai.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; } // เช่น: โปรโมชั่น, ของคาว, ของหวาน, น้ำดื่ม
    }
}