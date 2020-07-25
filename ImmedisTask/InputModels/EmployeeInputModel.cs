using ImmedisTask.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ImmedisTask.InputModels
{
    public class EmployeeInputModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date joined company")]
        public DateTime DateJoinedCompany { get; set; }

        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Job title")]
        public string JobTitle { get; set; }

        /// <summary>
        ///  If false, it is considered anually
        /// </summary>
        ///
        [Required]
        [DisplayName("Salary is monthly")]
        public bool IsMonthly { get; set; }

        [Required]
        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [Required]
        [DisplayName("Department")]
        public string Department { get; set; }

        [Required]
        [DisplayName("Line manager employee")]
        public int? LineManagerEmployeeId { get; set; }

        public IEnumerable<EmployeeViewModel> LineEmployees { get; set; }

        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }
    }
}