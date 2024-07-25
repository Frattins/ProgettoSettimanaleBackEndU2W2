namespace ProgettoSettimanaleBackEndU2W2.Models
{
    public class ReservationDetail
    {
        public int DetailID { get; set; } // Chiave primaria
        public int ReservationID { get; set; }
        public string RoomNumber { get; set; }
        public string Period { get; set; }
        public decimal RateApplied { get; set; }
        public string AdditionalServicesList { get; set; }
        public decimal TotalAmountToPay { get; set; }
    }
}
