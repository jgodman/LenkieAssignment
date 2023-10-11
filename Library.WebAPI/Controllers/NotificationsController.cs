using JsonFileDAO;
using Library.Core;
using Library.IData;
using Library.WebAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    /// <summary>
    /// This controller contains endpoints for notifications
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        /// <summary>
        /// Controller constructor, through which all services are injected.
        /// </summary>
        private readonly INotificationDAO _notificationDAO;
        private readonly IBookDAO _bookDAO;
        public NotificationsController(INotificationDAO notificationDAO, IBookDAO bookDAO)
        {
            _notificationDAO = notificationDAO;
            _bookDAO = bookDAO;
        }

        /// <summary>
        /// This endpoint provides the user with the functionality to request
        /// to be notified when next a book becomes available.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("NotifyCustomer")]
        public BaseResponse NotifyCustomer(NotificationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new BaseResponse
                {
                    Message = "Invalid request."
                };
            }

            //Check if the customer exists
            #region

            #endregion

            //Check if book is available
            var book = _bookDAO.Get(request.BookID);

            if (book == null)
            {
                return new BaseResponse
                {
                    Message = "The book does not exist."
                };
            }

            if (book.Status == BookStatus.Available)
            {
                return new BaseResponse
                {
                    Message = $"'{book.Title}' is available at the moment. You can borrow it right away."
                };
            }

            _notificationDAO.Insert(new Notification
            {
                BookID = book.ID,
                RequestDate = DateTime.UtcNow,
                Recipient = request.CustomerID
            });

            return new BaseResponse
            {
                IsSuccessful = true,
                Message = "You will be notified once the book is available"
            };
        }

    }
}
