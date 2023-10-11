using Library.Core;
using Library.IData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Library.JsonFileDAO
{
    public class BookDAO : IBookDAO
    {
        static List<Book> _books = new();
        static Dictionary<int, Book> _booksDict = new();
        readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\StaticData\Books.json");
        public BookDAO()
        {
            if (_books.Count == 0)
            {
                string staticData = File.ReadAllText(filePath);
                _books = JsonConvert.DeserializeObject<List<Book>>(staticData);
                _booksDict = _books.ToDictionary(b => b.ID);
            }
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
            throw new NotImplementedException();
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
                Update(bookSearched);
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

        /// <summary>
        /// This saves all the data in a flat file, asynchronously.
        /// </summary>
        private void Commit()
        {
            try
            {
                Task.Run(() =>
                {
                    File.WriteAllText(filePath, JsonConvert.SerializeObject(_books));
                });
            }
            catch(Exception)
            {

            }
        }

        public Book Update(Book entity)
        {
            Commit();
            return entity;
        }
    }
}
