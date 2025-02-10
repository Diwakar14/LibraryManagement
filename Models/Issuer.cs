namespace LibraryManagement.Models
{
    public class Issuer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? IsMembershipActive { get; set; }
        public string? MembershipType { get; set; }
        public DateTime? MembershipExpireDate { get; set; }
        public IList<BookIssuer>? Books { get; set; }

        public Issuer()
        {
            Books = new List<BookIssuer>();
        }
    }
}
