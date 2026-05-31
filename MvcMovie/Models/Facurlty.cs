using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        [Required]
        public string FacultyName { get; set; } = string.Empty;

        public ICollection<Student>? Students { get; set; }
    }
}