using Library.Core;
using Library.IData;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JsonFileDAO
{
    public class BookDAO : IBookDAO
    {
        List<Book> _books = new();
        Dictionary<int, Book> _booksDict = new();

        public BookDAO()
        {
            string staticData = File.ReadAllText("/StaticData/Books.json");
            _books = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Book>>(staticData);
            _booksDict = _books.ToDictionary(b => b.ID);
        }

        public bool Borrow(int bookID)
        {
            return ShouldBorrowOrReserve(bookID, false);
        }

        /// <summary>
        /// Fetches a book by ID
        /// </summary>
        /// <param name="bookID">The ID of the book</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Book Get(int bookID)
        {
            _booksDict.TryGetValue(bookID, out Book book);
            return book;
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        /// <summary>
        /// This adds a new book.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int Insert(Book entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Reserve(int bookID)
        {
            return ShouldBorrowOrReserve(bookID, false);
        }

        private bool ShouldBorrowOrReserve(int bookID, bool isBorrow = true)
        {
            if (_booksDict.TryGetValue(bookID, out Book bookSearched))
            {
                if (bookSearched.Status != BookStatus.Available)
                {
                    return false;
                }
                bookSearched.Status = isBorrow ? BookStatus.Borrowed : BookStatus.Reserved;
                _booksDict[bookID] = bookSearched;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Book> Search(string searchText)
        {
            bool searchTextIsNumber = int.TryParse(searchText, out int searchNumber);

            var query =
                _books.Where(book =>
                    book.Title.Contains(searchText) 
                    || book.Author.Contains(searchText) 
                    || (searchTextIsNumber && 
                                (book.Year == searchNumber || book.PageCount == searchNumber)));

            return query.ToList();
        }

        public Book Update(Book entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
