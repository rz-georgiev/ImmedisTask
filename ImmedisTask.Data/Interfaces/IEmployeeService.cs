using ImmedisTask.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImmedisTask.Data.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetByIdAsync(int? id);

        Task<bool> SaveChangesAsync(Employee employee);

        IEnumerable<Employee> GetAll();
    }
}