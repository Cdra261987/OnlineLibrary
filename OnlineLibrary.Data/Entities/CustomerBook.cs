namespace OnlineLibrary.Data.Entities
{
    public class CustomerBook
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime InitialRentTime { get; set; }
        public DateTime FinalRentTime { get; set; }
    }
}