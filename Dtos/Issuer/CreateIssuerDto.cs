namespace LibraryManagement.Dtos.Issuer
{
    public class CreateIssuerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? IsMembershipActive { get; set; }
        public string? MembershipType { get; set; }
        
    }
}
