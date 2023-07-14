namespace AdminPortalApi.DTOs
{
    public class TeacherDTO : BaseDTO
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime BirtDate { get; set; }
        public int CourseId { get; set; }
    }
}
