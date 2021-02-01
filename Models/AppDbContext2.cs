using Microsoft.EntityFrameworkCore;

namespace eVisitor_mvcnet5.Models
{
    public class AppDbContext2 : DbContext
    {
        // inject

        // ctor
        public AppDbContext2(DbContextOptions<AppDbContext2> options) : base(options)
        {

        }

        public DbSet<m_cls_ToDo> tbl_ToDos { get; set; }
        public DbSet<m_cls_Category> tbl_Categories { get; set; }
        public DbSet<m_cls_Status> tbl_Statuses { get; set; }
        public DbSet<m_cls_Transaction> tbl_Transactions { get; set; }
        public DbSet<m_cls_Image> tbl_Images { get; set; }

        // EF DBSet for Dapper test
        public DbSet<m_cls_Company_D> tbl_Company_D { get; set; }


        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<m_cls_Category>().HasData(
            new m_cls_Category { CategoryId = "work", Name = "Work"},
            new m_cls_Category { CategoryId = "home", Name = "Home" },
            new m_cls_Category { CategoryId = "ex", Name = "Exercise" },
            new m_cls_Category { CategoryId = "shop", Name = "Shopping" },
            new m_cls_Category { CategoryId = "contact", Name = "Contact" }
            );

        modelBuilder.Entity<m_cls_Status>().HasData(
            new m_cls_Status { StatusId = "open", Name = "Open"},
            new m_cls_Status { StatusId = "closed", Name = "Completed" }
            );
        } */

    }
}