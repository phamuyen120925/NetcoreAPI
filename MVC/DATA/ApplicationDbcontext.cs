using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        public DbSet<DeviceCategory> DeviceCategory { get; set; }

        public DbSet<Device> Device { get; set; }
        public DbSet<ImportReceipt> ImportReceipt { get; set; }

        public DbSet<ImportDetail> ImportDetail { get; set; }
        public DbSet<ExportReceipt> ExportReceipt { get; set; }

        public DbSet<ExportDetail> ExportDetail { get; set; }
    }
}