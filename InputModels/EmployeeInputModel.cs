using ImmedisTask.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ImmedisTask.InputModels
{
    public class EmployeeInputModel
    {
        public int Id { get; set; }

        public DateTime DateJoinedCompany { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        /// <summary>
        ///  If false, it is considered anually
        /// </summary>
        public bool IsMonthly { get; set; }

        public decimal Amount { get; set; }

        public string Department { get; set; }

        public int? LineManagerEmployeeId { get; set; }

        public Employee LineManagerEmployee { get; set; }

        public IEnumerable<Employee> LineEmployees { get; set; }

        public string Address { get; set; }
    }
}