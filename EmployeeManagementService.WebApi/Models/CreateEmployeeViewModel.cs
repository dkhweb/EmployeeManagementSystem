using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementService.WebApi.Models
{
    public class CreateEmployeeViewModel
    {        
        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string LastName { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public DepartmentViewModel Department { get; set; }
    }
}
