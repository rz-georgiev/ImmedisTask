using ImmedisTask.ViewModels.Employee;
using System.Collections.Generic;

namespace ImmedisTask.ViewModels.Employee
{
    public class IndexViewModel
    {
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}