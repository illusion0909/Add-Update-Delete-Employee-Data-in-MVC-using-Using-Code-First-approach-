using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DotNet_Project05.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        [Display(Name = "Employee Address")]
        public string Address { get; set; }
        [Display(Name = "Employee Salary")]
        public int Salary { get; set; }
        [Display(Name = "Employee Age")]
        public int Age { get; set; }
    }
}