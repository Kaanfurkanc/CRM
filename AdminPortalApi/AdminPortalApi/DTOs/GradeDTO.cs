namespace AdminPortalApi.DTOs
{
    public class GradeDTO : BaseDTO
    {
        public double Point { get; set; }
        public bool PassedStatus { get; set; }
        public int ExamId { get; set; }
    }
}
