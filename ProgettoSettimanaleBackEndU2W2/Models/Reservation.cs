using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanaleBackEndU2W2.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        public int ClientID { get; set; }
        public int RoomID { get; set; }
        public DateTime ReservationDate { get; set; }
        public int ProgressiveNumber { get; set; }
        public int Year { get; set; }
        public DateTime StayFrom { get; set; }
        public DateTime StayTo { get; set; }
        public decimal Deposit { get; set; }
        public decimal RateApplied { get; set; }
        public string Details { get; set; }
    }
}