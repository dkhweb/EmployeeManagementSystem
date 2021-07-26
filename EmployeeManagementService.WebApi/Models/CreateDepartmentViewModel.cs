using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementService.WebApi.Models
{
    public class CreateDepartmentViewModel
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
    }
}
