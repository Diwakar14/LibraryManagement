namespace LibraryManagement.Models
{
    public class Library : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime EstabishedOn { get; set; }
    }
}
