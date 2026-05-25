using System.ComponentModel.DataAnnotations;

namespace Practical_20.Model.Entities
{
    public class Employee:BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public float Salary { get; set; }

        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
    }
}
