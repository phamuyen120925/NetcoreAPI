using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Faculty
    {
        [Key]
        public string FacultyID { get; set; }

        public string FacultyName { get; set; }

        public ICollection<Student>? Students { get; set; }
    }
}