namespace rft.Models
{
    public class User
    {
        public int Id { get; set; }
        public string role { get; set; } // admin, teacher, student
        public string name { get; set; }
    }
}
