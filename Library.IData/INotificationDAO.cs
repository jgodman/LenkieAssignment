using Library.Core;
using System.Collections.Generic;

namespace Library.IData
{
    public interface INotificationDAO<T> : IBaseDAO<T> where T: Notification
    {
        
    }
}
