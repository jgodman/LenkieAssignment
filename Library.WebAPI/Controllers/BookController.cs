using JsonFileDAO;
using Library.Core;
using Library.IData;
using Library.WebAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BookController : ControllerBase
    {
        private IBookDAO _bookDAO;
        public BookController(IBookDAO bookDAO) {
            _bookDAO = bookDAO;
        }

        // GET: api/<BookController>
        /// <summary>
        /// Fetches the list of books in the library.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBooksList")]
        public List<Book> Get()
        {
            return _bookDAO.GetAll();
        }


        // GET api/<BookController>/5
        /// <summary>
        /// This method fetches a particular book by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _bookDAO.Get(id);
        }

        /// <summary>
        /// This endpoint facilitates borrowing the book.
        /// </summary>
        /// <param name="bookID">The ID of the book to be borrowed.</param>
        /// <returns>The status of the request. <see cref="BaseResponse.IsSuccessful"/> indicates whether the borrow
        /// operation was successful. <see cref="BaseResponse.Message"/> indicates the message when it isn't. </returns>
        // POST api/<BookController>
        [HttpPost("Borrow")]
        public BaseResponse Borrow(int bookID)
        {
            var isSuccessful = _bookDAO.Borrow(bookID);
            return new BaseResponse
            {
                IsSuccessful = isSuccessful,
                Message = isSuccessful ? "Borrowed successfully" : "We are sorry the book is not available to be borrowed."
            };
        }

        /// <summary>
        /// This endpoint facilitates reserving a book.
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns>The status of the request. <see cref="BaseResponse.IsSuccessful"/> indicates whether the reserve
        /// operation was successful. <see cref="BaseResponse.Message"/> indicates the message when it isn't. </returns>
        // POST api/<BookController>
        [HttpPost("Reserve")]
        public BaseResponse Reserve(int bookID)
        {
            var isSuccessful = _bookDAO.Borrow(bookID);
            return new BaseResponse
            {
                IsSuccessful = isSuccessful,
                Message = isSuccessful ? "Borrowed successfully" : "We are sorry the book is not available to be borrowed."
            };
        }
        
    }
}
