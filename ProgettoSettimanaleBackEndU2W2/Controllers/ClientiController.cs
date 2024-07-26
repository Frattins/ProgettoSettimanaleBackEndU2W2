using Microsoft.AspNetCore.Mvc;
using ProgettoSettimanaleBackEndU2W2.Models;
using ProgettoSettimanaleBackEndU2W2.Interface;
using System.Threading.Tasks;

namespace ProgettoSettimanaleBackEndU2W2.Controllers
{
    public class ClientiController : Controller
    {
        private readonly IClienteDao _clienteDao;

        public ClientiController(IClienteDao clienteDao)
        {
            _clienteDao = clienteDao;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _clienteDao.GetAllClientsAsync();
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                await _clienteDao.AddClientAsync(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = await _clienteDao.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                await _clienteDao.UpdateClientAsync(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = await _clienteDao.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clienteDao.DeleteClientAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
