using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanaleBackEndU2W2.Models
{
    public class ReservationDetail
    {
        [Key]
        public int DetailID { get; set; }

        public int ReservationID { get; set; }
        public int RoomNumber { get; set; }
        public string Period { get; set; }
        public decimal RateApplied { get; set; }
        public string AdditionalServicesList { get; set; }
        public decimal TotalAmountToPay { get; set; }
    }
}