using CsvHelper.Configuration.Attributes;

namespace LibraryManagement.Models
{
    public class Book : Entity
    {
        [Index(0)]
        public string Title { get; set; } = string.Empty;  
        public string Author { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float? AvgRating { get; set; }
        public string? ISBN { get; set; }
        public string? ISBN13 { get; set; }
        public string? LanguageCode { get; set; } = "en";
        public int? NumberOfPages { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? Publisher { get; set; } = string.Empty;
        public float? Price { get; set; }

        public IList<BookIssuer>? Issuers { get; set; }

        public Book()
        {
            Issuers = new List<BookIssuer>();
        }
    }
}
