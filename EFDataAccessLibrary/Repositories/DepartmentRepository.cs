using System;
using System.Collections.Generic;
using System.Text;
using EFDataAccessLibrary.Interfaces;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace EFDataAccessLibrary.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(PlutoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Department>> GetAllWithEmployees()
        {
            return await PlutoContext.Departments
                .Include(x => x.Employees)
                .ToListAsync();
        }

        public async Task<Department> GetWithEmployees(int id)
        {
            return await PlutoContext.Departments
                .Include(x => x.Employees)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }
}
