using ImmedisTask.Data;
using ImmedisTask.Data.Interfaces;
using ImmedisTask.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImmedisTask.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ImmedisDbContext _dbContext;

        public EmployeeService(ImmedisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dbContext.Employees;
        }

        public async Task<Employee> GetByIdAsync(int? id)
        {
            return await _dbContext.Employees
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SaveChangesAsync(Employee employee)
        {
            try
            {
                if (employee.Id == 0)
                {
                    await _dbContext.AddAsync(employee);
                }
                else
                {
                    _dbContext.Update(employee);
                }
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}