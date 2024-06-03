namespace OnlineLibrary.Domain.Entities
{
	public class CustomerBook
	{
  public int Id { get; set; }
  public int CustomerId { get; set; }
  public Customer Customer { get; set; }
  
  public int BookId { get; set; }
  public Book book { get; set; }
		public DateTime InitialRentTime { get; set; }
  public DateTime FinalRentTime { get; set; }
  
	}
}
