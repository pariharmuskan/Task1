namespace Task1.Models
{
    public class LeaveRequest
    {

       
            public int Id { get; set; }
            public int EmployeeId { get; set; }
            public Employee Employee { get; set; }
            public DateOnly StartDate { get; set; }
            public DateOnly EndDate { get; set; }
            public bool Approved { get; set; }
           
    }
}
