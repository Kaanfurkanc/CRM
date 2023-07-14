namespace AdminPortalApi.DTOs
{
    public class StudentDTO : BaseDTO
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int StudentNo { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime BirtDate { get; set; }
        public int ClassId { get; set; }
    }
}
