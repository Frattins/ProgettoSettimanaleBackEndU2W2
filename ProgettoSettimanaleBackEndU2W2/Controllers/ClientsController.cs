using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgettoSettimanaleBackEndU2W2.Interfaces;
using ProgettoSettimanaleBackEndU2W2.Models;

namespace ProgettoSettimanaleBackEndU2W2.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _clientRepository.GetAllClients());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Surname,Name,City,Province,Email,Phone,Mobile")] Client client)
        {
            if (ModelState.IsValid)
            {
                await _clientRepository.AddClient(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }
    }
}
