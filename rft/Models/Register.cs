using System.ComponentModel.DataAnnotations.Schema;

namespace rft.Models
{
    public class Register
    {
        public int Id { get; set; }
        [ForeignKey("Exam")]
        public int ExamId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
