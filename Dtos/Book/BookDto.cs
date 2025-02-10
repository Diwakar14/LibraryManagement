using LibraryManagement.Models;

namespace LibraryManagement.Dtos.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float AvgRating { get; set; }
        public int ISBN { get; set; }
        public int ISBN13 { get; set; }
        public string LanguageCode { get; set; } = "en";
        public int NumberOfPages { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public float Price { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}
