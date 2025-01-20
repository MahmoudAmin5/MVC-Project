using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC_Web.Models
{
    public class CompanyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog =CompanyMVCProject; Integrated Security = True; Encrypt = False");
        }
        public CompanyDbContext() : base() { }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<Empolyee>()
                .HasOne(s=>s.Department)
                .WithMany(s=>s.Employees)
                .HasForeignKey(s=>s.DepartmentID)
                .OnDelete(DeleteBehavior.NoAction);
        }
        public DbSet<Empolyee> Empolyees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
