namespace LibraryManagement.Models
{
    public class BatchFile : Entity
    {
        public string FileName { get; set; }
        public string Status { get; set; }

        public DateTime Date { get; set; }
    }
}
