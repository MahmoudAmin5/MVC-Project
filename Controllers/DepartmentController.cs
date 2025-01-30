using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Web.Models;

namespace MVC_Web.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyDbContext context=new CompanyDbContext();
        public IActionResult Index()
        {
            List<Department> ListDepartments = context.Departments.ToList();
            return View("Index",ListDepartments);
        }
        public IActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        public IActionResult SaveAdd(Department deptObj)
        {
            if (deptObj.Name != null)
            {
                context.Departments.Add(deptObj);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Add",deptObj);// Model

        }

    }
}
