using System;
using System.Collections.Generic;

namespace Library.Core
{
    public class Notification
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
        public DateTime DateAvailable { get; set; }
        public List<int> RecipientCustomers { get; set; }
    }
}
