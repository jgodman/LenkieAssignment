using Library.Core;
using System.Collections.Generic;
using System.IO;
using System;
using Newtonsoft.Json;
using Library.IData;
using System.Threading.Tasks;

namespace Library.JsonFileDAO
{
    public class NotificationDAO : INotificationDAO
    {

        static List<Notification> _notifications = new();
        readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\StaticData\Notifications.json");

        public NotificationDAO()
        {
            if (_notifications.Count == 0)
            {
                string staticData = File.ReadAllText(filePath);
                _notifications = JsonConvert.DeserializeObject<List<Notification>>(staticData);
            }
        }

        public List<Notification> GetAll()
        {
            return _notifications;
        }

        public int Insert(Notification entity)
        {
            _notifications.Add(entity);
            Commit();
            return 1;
        }

        /// <summary>
        /// This saves the data in a flat file, asynchronously.
        /// </summary>
        private void Commit()
        {
            try
            {
                Task.Run(() =>
                {
                    File.WriteAllText(filePath, JsonConvert.SerializeObject(_notifications));
                });
                
            }
            catch (Exception)
            {

            }
        }
    }
}
