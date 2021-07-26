using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFDataAccessLibrary.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]  
        [MaxLength(200)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        public int Salary { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
