using ImmedisTask.Data.Interfaces;
using ImmedisTask.ViewModels.Employee;
using ImmedisTask.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ImmedisTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService
                .GetAll()
                .OrderByDescending(x => x.DateJoinedCompany);

            var employeeModels = employees.Select(x => new EmployeeViewModel
            {
                Id = x.Id,
                DepartmentName = x.Department,
                JobTitle = x.JobTitle,
                Name = $"{x.FirstName} {x.LastName}",
                Salary = x.Amount,
                JoinDate = x.DateJoinedCompany.ToString("dd.MM.yyyy")
            });

            var model = new IndexViewModel { Employees = employeeModels };

            return View(model);
        }
    }
}