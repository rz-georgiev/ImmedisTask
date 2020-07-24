using System.Collections.Generic;

namespace ImmedisTask.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}