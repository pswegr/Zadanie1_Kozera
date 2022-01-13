using System.ComponentModel.DataAnnotations;

namespace Zadanie1_Kozera.Models
{
    public class Team
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
    }
}
