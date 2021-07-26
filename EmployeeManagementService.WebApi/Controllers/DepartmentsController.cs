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
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Department> departments = await _unitOfWork.Departments.GetAllWithEmployees();
            
            var dvm = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDTO>>(departments);

            return new JsonResult(dvm);
        }

        //GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest();

            Department department = await _unitOfWork.Departments.GetWithEmployees(id);

            if (department is null)
                return NotFound();

            var dvm = _mapper.Map<DepartmentDTO>(department);

            return new JsonResult(dvm);
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDepartmentViewModel cvm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            IEnumerable<Department> deps = _unitOfWork.Departments.Find(x => x.Name == cvm.Name);
            if (deps.Any())
                return BadRequest(new { Error = "The department exists" });

            var department = _mapper.Map<Department>(cvm);

            await _unitOfWork.Departments.Add(department);
            await _unitOfWork.Complete();

            return Ok();
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DepartmentViewModel evm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Department deparment = await _unitOfWork.Departments.Get(evm.Id);

            if (deparment != null)
            {
                IEnumerable<Department> deps = _unitOfWork.Departments.Find(x => x.Name == evm.Name);
                if (deps.Any())
                    return BadRequest(new { Error = "The department exists" });

                deparment.Name = evm.Name;

                await _unitOfWork.Complete();

                return Ok();
            }

            return NotFound();
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var department = await _unitOfWork.Departments.Get(id);
            if (department is null) return NotFound();

            _unitOfWork.Departments.Remove(department);
            await _unitOfWork.Complete();

            return Ok();
        }
    }
}
