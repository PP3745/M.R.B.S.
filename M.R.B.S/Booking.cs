using System;

namespace M.R.B.S_
{
    public class Booking
    {
        public string BookingID { get; set; } = string.Empty;
        public string RoomName { get; set; } = string.Empty;
        public string BookerName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Purpose { get; set; } = string.Empty;
    }
}