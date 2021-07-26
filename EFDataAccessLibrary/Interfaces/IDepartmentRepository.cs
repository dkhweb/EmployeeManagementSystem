using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models;

namespace EFDataAccessLibrary.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllWithEmployees();
        Task<Department> GetWithEmployees(int id);        
    }
}
