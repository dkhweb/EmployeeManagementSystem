using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFDataAccessLibrary.Models
{
    [Index("Name", IsUnique = true)]
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]        
        public string Name { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
