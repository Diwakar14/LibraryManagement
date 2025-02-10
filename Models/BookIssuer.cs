using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class BookIssuer : Entity
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int IssuerId { get; set; }
        public Issuer Issuer { get; set; }
    }
}
