using System;

namespace Library.Core
{
    public class BookReservationHistory
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
        public DateTime DateReserved { get; set; }
        public DateTime DateReservationExpired { get; set; }
        public int ReservingUserID { get; set; }
    }
}
