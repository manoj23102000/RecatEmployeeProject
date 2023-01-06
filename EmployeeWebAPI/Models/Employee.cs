using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeWebAPI.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string EmployeeName { get; set; }
        [StringLength(50)]
        public string Band { get; set; }
        [StringLength(200)]
        public string Role { get; set; }
        [StringLength(50)]
        public string Designation { get; set; }
        [StringLength(300)]
        public string Responsibilities { get; set; }
    }
}
