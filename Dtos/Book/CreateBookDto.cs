using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Dtos.Book
{
    public class CreateBookDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Author { get; set; } = string.Empty;
        public float AvgRating { get; set; }
        public int ISBN { get; set; }
        public int ISBN13 { get; set; }

        public int Quantity { get; set; }

        [MaxLength(10)]
        public string LanguageCode { get; set; } = "en";
        public int NumberOfPages { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public float Price { get; set; }
    }
}
