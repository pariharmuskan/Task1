using System.ComponentModel.DataAnnotations;

namespace Task1.Models
{
    public class User
    {
        
            [Key] public int Id { get; set; }
            public string? Name { get; set; }
            public double? Phone { get; set; }
            public string? Email { get; set; }
            public string? Address { get; set; }
            public DateOnly? Dob { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public string? Role { get; set; }
        public virtual Employee Employee { get; set; }




    }
}
