namespace ProgettoSettimanaleBackEndU2W2.Models
{
    public class AdditionalService
    {
        public int ServiceID { get; set; }
        public int ReservationID { get; set; }
        public string ServiceName { get; set; }
        public DateTime ServiceDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
