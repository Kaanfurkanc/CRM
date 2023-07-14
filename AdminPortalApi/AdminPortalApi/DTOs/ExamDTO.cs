namespace AdminPortalApi.DTOs
{
    public class ExamDTO : BaseDTO
    {
        public string? ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public string? ExamDescription { get; set; }
        public int CourseId { get; set; }
    }
}
