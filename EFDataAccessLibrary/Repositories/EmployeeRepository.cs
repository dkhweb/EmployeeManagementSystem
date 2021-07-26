using EFDataAccessLibrary.Interfaces;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(PlutoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllWithDepartment()
        {
            return await PlutoContext.Employees
                .Include(x => x.Department)
                .ToListAsync();
        }

        public async Task<Employee> GetWithDepartment(int id)
        {
            return await PlutoContext.Employees
                .Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }
}