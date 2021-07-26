using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EFDataAccessLibrary.Models;
using EmployeeManagementService.WebApi.Models;

namespace EmployeeManagementService.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Department, DepartmentDTO>();
            CreateMap<CreateEmployeeViewModel, Employee>();
            CreateMap<CreateDepartmentViewModel, Department>();
            CreateMap<DepartmentViewModel, Department>().ReverseMap();
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
