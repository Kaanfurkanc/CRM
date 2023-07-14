namespace AdminPortalApi.DTOs
{
    public class AnnouncementDTO : BaseDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int SchoolId { get; set; }
    }
}
