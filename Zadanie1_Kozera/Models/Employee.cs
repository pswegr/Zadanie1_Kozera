using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zadanie1_Kozera.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Display(Name ="First Name")]
        public string FirstMidName { get; set; }
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal AddicionalSalary { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstMidName; }
        }
    }
}
