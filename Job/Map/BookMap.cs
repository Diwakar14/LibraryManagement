using CsvHelper.Configuration;
using LibraryManagement.Models;

namespace LibraryManagement.Job.Map
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Map(p => p.Title).Index(1);
            Map(p => p.Author).Index(2);
            Map(p => p.AvgRating).Index(3);
            Map(p => p.ISBN).Index(4);
            Map(p => p.ISBN13).Index(5);
            Map(p => p.LanguageCode).Index(6);
            Map(p => p.NumberOfPages).Index(7);
            Map(p => p.PublicationDate).Index(10);
            Map(p => p.Publisher).Index(11);
        }
    }
}
