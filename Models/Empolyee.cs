using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Web.Models
{
    public class Empolyee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public int Salary {get; set; }
        public string ImageURL { get; set; }
        public string Address {  get; set; }
        [ForeignKey("Department")]
        public int DepartmentID {  get; set; }

        public Department Department { get; set; }




    }
}
