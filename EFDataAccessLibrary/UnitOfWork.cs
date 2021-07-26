using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Interfaces;
using EFDataAccessLibrary.Repositories;

namespace EFDataAccessLibrary
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlutoContext _context;
        public IDepartmentRepository Departments { get; private set; }
        public IEmployeeRepository Employees { get; private set; }

        
        public UnitOfWork(PlutoContext context, IEmployeeRepository employees, IDepartmentRepository department)
        {
            _context = context;
            Employees = employees;
            Departments = department;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
