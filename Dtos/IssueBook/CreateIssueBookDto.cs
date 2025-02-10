namespace LibraryManagement.Dtos.IssueBook
{
    public class CreateIssueBookDto
    {
        public int BookId { get; set; }
        public int IssuerId { get; set; }
        public int Quantity { get; set; }
    }
}
