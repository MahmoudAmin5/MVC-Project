using MVC_Web.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Web.ViewModel
{
    public class EmpsWithDeptList
    {
        public List<Department> DepartmentsList { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public string ImageURL { get; set; }
        public string Address { get; set; }
        public int DepartmentID { get; set; }
    }
}
