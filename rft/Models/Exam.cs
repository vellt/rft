namespace rft.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int TeacherId { get; set; } 
        public DateTime DateTime { get; set; }
        public string Course { get; set; } // course name of the exam
        public string Location { get; set; } // room
    }
}
