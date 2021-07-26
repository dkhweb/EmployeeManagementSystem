using AutoMapper;
using EFDataAccessLibrary.Interfaces;
using EFDataAccessLibrary.Models;
using EmployeeManagementService.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementService.WebApi.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Employee> employees = await _unitOfWork.Employees.GetAllWithDepartment();
            
            var evm = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);

            return new JsonResult(evm);
        }

        //GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Employee employee = await _unitOfWork.Employees.GetWithDepartment(id);

            if (employee is null)
                return NotFound();

            var evm = _mapper.Map<EmployeeViewModel>(employee);

            return new JsonResult(evm);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeViewModel cvm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Department department = await _unitOfWork.Departments.Get(cvm.Department.Id);

            if (department is null)
                return BadRequest();

            var employee = _mapper.Map<Employee>(cvm);
            employee.Department = department;

            await _unitOfWork.Employees.Add(employee);
            await _unitOfWork.Complete();

            return Ok();
        }       

        // PUT api/<EmployeesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EmployeeViewModel evm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Employee employee = await _unitOfWork.Employees.Get(evm.Id);
            Department deparment = await _unitOfWork.Departments.Get(evm.Department.Id);

            if (employee != null && deparment != null)
            {
                employee.FirstName = evm.FirstName;
                employee.LastName = evm.LastName;
                employee.Salary = evm.Salary;
                employee.Department = deparment;
                
                await _unitOfWork.Complete();

                return Ok();
            }            

            return NotFound();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            Employee employee = await _unitOfWork.Employees.Get(id);
            if (employee is null) return NotFound();

            _unitOfWork.Employees.Remove(employee);
            await _unitOfWork.Complete();

            return Ok();
        }
    }
}
