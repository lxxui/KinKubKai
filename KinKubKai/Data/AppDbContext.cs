using KinKubKai.Models;
using Microsoft.EntityFrameworkCore;

namespace KinKubKai.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // 📌 ประกาศตารางทั้งหมดที่จะให้มีใน Database จริง
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}