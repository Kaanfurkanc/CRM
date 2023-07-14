namespace AdminPortalApi.DTOs
{
    public class CourseDTO : BaseDTO
    {
        public string? Name { get; set; }
        public string? CourseCode { get; set; }
        public string? Description { get; set; }
        public int Credit { get; set; }
        public int StudentId { get; set; }
    }
}
