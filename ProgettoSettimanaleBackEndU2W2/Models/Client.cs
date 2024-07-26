using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanaleBackEndU2W2.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        public string Code { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}