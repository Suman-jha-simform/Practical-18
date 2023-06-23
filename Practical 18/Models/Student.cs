using System.ComponentModel.DataAnnotations;

namespace Practical_18.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-z ]){2,20}", ErrorMessage = "Name can only have alphabets")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^([a-zA-z ]){1,20}", ErrorMessage = "Department can only have alphabets")]
        public string Department { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^(10(\.00?)?|[0-9](\.[0-9]{1,2})?)$", ErrorMessage = "Grades can be number between 0 to 10 with precision of 2")]
        public decimal Grades { get; set; }
    }
}
