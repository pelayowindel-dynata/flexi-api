namespace flexi.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; } = string.Empty;
        public string StudentLastName { get; set; } = string.Empty;
        public string StudentEmail { get; set; } = string.Empty;
        public string StudentPassword { get; set; } = string.Empty;
    }
}