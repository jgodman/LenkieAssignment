using System.ComponentModel.DataAnnotations;

namespace Library.Core
{
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

    public enum BookStatus
    {
        Available,
        Reserved,
        Borrowed
    }
}
