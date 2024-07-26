using ProgettoSettimanaleBackEndU2W2.Interface;
using ProgettoSettimanaleBackEndU2W2.Models;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoSettimanaleBackEndU2W2.Services
{
    public class AuthService : IAuthService
    {
        private readonly IClienteDao _clienteDao;

        public AuthService(IClienteDao clienteDao)
        {
            _clienteDao = clienteDao;
        }

        public async Task<bool> RegisterAsync(Client client)
        {
            client.Password = HashPassword(client.Password);
            return await _clienteDao.AddClientAsync(client);
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var client = await _clienteDao.GetClientByEmailAsync(email);
            if (client == null || !VerifyPassword(password, client.Password))
            {
                return false;
            }
            return true;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput == hashedPassword;
        }
    }
}
