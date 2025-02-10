namespace LibraryManagement.Exceptions
{
    public class OutOfStockException : Exception
    {
        public OutOfStockException()
        {
            
        }

        public OutOfStockException(string message) : base(message)  
        {
            
        }
    }
}
