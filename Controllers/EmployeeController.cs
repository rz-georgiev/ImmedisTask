using ImmedisTask.Data.Interfaces;
using ImmedisTask.Data.Models;
using ImmedisTask.InputModels;
using ImmedisTask.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImmedisTask.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(int? employeeId)
        {
            var lineEmployees = _employeeService.GetAll();
            var lineEmployeesModels = lineEmployees.Select(x => new EmployeeViewModel
            {
                Id = x.Id,
                Name = $"{x.FirstName} {x.LastName}"
            });

            var employee = await _employeeService.GetByIdAsync(employeeId);
            if (employee == null)
            {
                var model = new EmployeeInputModel
                {
                    LineManagerEmployeeId = 0,
                    LineEmployees = lineEmployeesModels,
                    DateJoinedCompany = DateTime.Now
                };

                return View(model);
            }
            else
            {
                var inputModel = new EmployeeInputModel
                {
                    Id = employee.Id,
                    Address = employee.Address,
                    Amount = employee.Amount,
                    DateJoinedCompany = employee.DateJoinedCompany,
                    Department = employee.Department,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    IsMonthly = employee.IsMonthly,
                    JobTitle = employee.JobTitle,
                    LineManagerEmployeeId = employee.LineManagerEmployeeId,
                    LineEmployees = lineEmployeesModels,
                };

                return View(inputModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(EmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var lineEmployees = _employeeService.GetAll();
                var lineEmployeesModels = lineEmployees.Select(x => new EmployeeViewModel
                {
                    Id = x.Id,
                    Name = $"{x.FirstName} {x.LastName}"
                });

                model.LineEmployees = lineEmployeesModels;

                return View(model);
            }

            var employee = await _employeeService.GetByIdAsync(model.Id);
            if (employee == null)
            {
                employee = new Employee
                {
                    Address = model.Address,
                    Amount = model.Amount,
                    DateJoinedCompany = model.DateJoinedCompany,
                    Department = model.Department,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    IsMonthly = model.IsMonthly,
                    JobTitle = model.JobTitle,
                    LineManagerEmployeeId = model.LineManagerEmployeeId,
                    CreatedDateTime = DateTime.Now,
                    IsActive = true
                };
            }
            else
            {
                employee.Address = model.Address;
                employee.Amount = model.Amount;
                employee.DateJoinedCompany = model.DateJoinedCompany;
                employee.Department = model.Department;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.IsMonthly = model.IsMonthly;
                employee.JobTitle = model.JobTitle;
                employee.LineManagerEmployeeId = model.LineManagerEmployeeId;
                employee.LastUpdatedDateTime = DateTime.Now;
            }

            await _employeeService.SaveChangesAsync(employee);
            return Redirect("/Home/Index");
        }
    }
}