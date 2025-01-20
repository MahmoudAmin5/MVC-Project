namespace MVC_Web.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? ManagerName { get; set; }

        public List<Empolyee>?Employees { get; set; }
    }
}
