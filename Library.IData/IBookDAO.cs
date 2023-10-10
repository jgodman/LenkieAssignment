using Library.Core;
using System.Collections.Generic;

namespace Library.IData
{
    public interface IBookDAO : IDAO<Book>
    {
        /// <summary>
        /// This updates the DB with the status of the book as reserved.
        /// </summary>
        /// <param name="book"></param>
        /// <returns>TRUE, if the book was found and the update was successful.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool Reserve(int bookID);
        /// <summary>
        /// This updates the DB with the status of the book as borrowed.
        /// </summary>
        /// <param name="book"></param>
        /// <returns>TRUE, if the book was found and the update was successful.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool Borrow(int bookID);
        public List<Book> Search(string searchText);
    }
}
