namespace LibraryManagement.Models
{
    public class Membership : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty ;
        public string Description { get; set; } = string.Empty;
    }
}
