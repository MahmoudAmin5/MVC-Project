using Microsoft.AspNetCore.Mvc;
using MVC_Web.Models;
using MVC_Web.ViewModel;

namespace MVC_Web.Controllers
{
    public class EmpolyeeController : Controller
    {
        CompanyDbContext context=new CompanyDbContext();
        public IActionResult Index()
        {
            return View("Index",context.Empolyees.ToList());
        }
        public IActionResult Edit(int id)
        {
            Empolyee empModel = context.Empolyees.FirstOrDefault(emp => emp.ID == id);
            List<Department> departmentsModel=context.Departments.ToList();
            if (empModel != null)
            {
                EmpsWithDeptList model= new EmpsWithDeptList();
                model.ID = empModel.ID;
                model.Name = empModel.Name;
                model.Salary = empModel.Salary;
                model.Address = empModel.Address;
               model.DepartmentID = empModel.DepartmentID;
                model.ImageURL = empModel.ImageURL;
                model.JobTitle = empModel.JobTitle;
                model.DepartmentsList= departmentsModel;
                return View("Edit", model);
            }
            return NotFound();

        }
        public IActionResult SaveEdit(EmpsWithDeptList emp) { 
            if(emp.Name != null)
            {
                Empolyee empDB = context.Empolyees.FirstOrDefault(e => e.ID == emp.ID);
                if (empDB != null)
                {
                    empDB.Name = emp.Name;
                    empDB.Salary = emp.Salary;
                    empDB.Address = emp.Address;
                    empDB.DepartmentID = emp.DepartmentID;
                    empDB.ImageURL = emp.ImageURL;
                    empDB.JobTitle = emp.JobTitle;
                    context.SaveChanges();
                    return RedirectToAction("Index"); 
                }
                return NotFound();

            }
            emp.DepartmentsList = context.Departments.ToList();
            return View("Edit",emp);
        
        }
        [HttpGet]
        public IActionResult New() {
            ViewData["DeptList"] = context.Departments.ToList();
            return View("New");
        }
        [HttpPost]
        public IActionResult SaveNew(Empolyee EmpFromReq)
        {
            if (EmpFromReq.Name != null && EmpFromReq.Salary >= 6000) { 
            // Save
               context.Empolyees.Add(EmpFromReq);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["DeptList"] = context.Departments.ToList();
            return View("New", EmpFromReq); 
        }

    }
}
