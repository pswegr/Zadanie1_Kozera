using System.ComponentModel.DataAnnotations;

namespace Zadanie1_Kozera.Models
{
    public class Job
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Display(Name ="Work From")]
        public int WorkFrom { get; set; }
        [Display(Name = "Work To")]
        public int WorkTo { get; set; }


    }
}
