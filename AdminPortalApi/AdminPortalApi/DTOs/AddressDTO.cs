namespace AdminPortalApi.DTOs
{
    public class AddressDTO : BaseDTO
    {
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Description { get; set; }
        public string? PostCode { get; set; }
        public int SchoolId { get; set; }
    }
}
