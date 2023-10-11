namespace Library.WebAPI.Model
{
    /// <summary>
    /// This entity takes the request of the user who wants to be notified of the availability of a book.
    /// </summary>
    public class NotificationRequest
    {
        /// <summary>
        /// The ID of the book.
        /// </summary>
        public int BookID { get; set; }
        /// <summary>
        /// The ID of the requesting customer.
        /// </summary>
        public int CustomerID { get; set; }
    }
}
