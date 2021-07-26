using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementService.WebApi.Models
{
    public class DepartmentViewModel
    {
        [Required]
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }
    }
}