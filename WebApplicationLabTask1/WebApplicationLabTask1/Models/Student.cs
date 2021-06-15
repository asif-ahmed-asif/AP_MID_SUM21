using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationLabTask1.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^([a-zA-Z '-]+)$", ErrorMessage = "Invalid Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Last name should be between 2 and 30 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "DOB is required")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1990", "31/12/2005", ErrorMessage = "DOB should be between 1/1/1990 and 31/12/2005")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Credit is required")]
        [Range(0, 148)]
        public int Credit { get; set; }
        [Required(ErrorMessage = "CGPA is required")]
        [Range(0, 4)]
        public double CGPA { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public string DeptId { get; set; }
        public string DeptName { get; set; }
    }
}