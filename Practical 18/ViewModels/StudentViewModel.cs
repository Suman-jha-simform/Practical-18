using System.ComponentModel.DataAnnotations;

namespace Practical_18.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Grades { get; set; }
    }
}
