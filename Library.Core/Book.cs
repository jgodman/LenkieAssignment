using System.ComponentModel.DataAnnotations;

namespace Library.Core
{
    /// <summary>
    /// This is the entity representing the books.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The ID field is kept in place to cater for instances where the ISBN
        /// is duplicated by any sort of error.
        /// </summary>
        [Key]
        public int ID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }
        public string Language { get; set; }
        public BookStatus Status { get; set; }
    }

    /// <summary>
    /// There are statuses:
    /// 0 - Available, 1 - Reserved, 2 - Borrowed
    /// </summary>
    public enum BookStatus
    {
        Available,
        Reserved,
        Borrowed
    }
}
