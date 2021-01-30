using Microsoft.EntityFrameworkCore;

namespace eVisitor_mvcnet5.Models
{
    public class AppDbContext : DbContext
    {
        // inject

        // ctor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<m_cls_Employee> Employees { get; set; } //Employees is Table

    }
}