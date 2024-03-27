namespace Task1.Models
{
   
        public class Employee
        {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Departments { get; set; }
        public string Designation { get; set; }
        public virtual User User { get; set; }


    }
}
