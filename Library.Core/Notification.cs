using System;
using System.Collections.Generic;

namespace Library.Core
{
    public class Notification
    {
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
        public DateTime RequestDate { get; set; }
        public int Recipient { get; set; }
        public DateTime TimeBookBecameAvailable { get; set; }
    }
}
