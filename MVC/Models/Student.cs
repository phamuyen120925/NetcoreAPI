using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Student
    {
        [Key]
        public string StudentID { get; set; }

        public string FullName { get; set; }

        public string FacultyID { get; set; }

        [ForeignKey("FacultyID")]
        public Faculty? Faculty { get; set; }
    }
}