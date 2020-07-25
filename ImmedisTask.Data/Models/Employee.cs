using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImmedisTask.Data.Models
{
    public class Employee : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateJoinedCompany { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string JobTitle { get; set; }

        /// <summary>
        ///  If false, it is considered anually
        /// </summary>
        ///
        [Required]
        public bool IsMonthly { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Department { get; set; }
  
        public int? LineManagerEmployeeId { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        [Required]
        public string Address { get; set; }
    }
}