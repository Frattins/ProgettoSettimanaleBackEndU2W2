using Microsoft.AspNetCore.Mvc;
using ProgettoSettimanaleBackEndU2W2.Interface;
using ProgettoSettimanaleBackEndU2W2.Models;
using System.Threading.Tasks;

namespace ProgettoSettimanaleBackEndU2W2.Controllers
{
    public class ServiziController : Controller
    {
        private readonly IServizioDao _servizioDao;

        public ServiziController(IServizioDao servizioDao)
        {
            _servizioDao = servizioDao;
        }

        public async Task<IActionResult> Index()
        {
            var servizi = await _servizioDao.GetAllAsync();
            return View(servizi);
        }

        public async Task<IActionResult> Details(int id)
        {
            var servizio = await _servizioDao.GetByIdAsync(id);
            if (servizio == null)
            {
                return NotFound();
            }
            return View(servizio);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdditionalService servizio)
        {
            if (ModelState.IsValid)
            {
                await _servizioDao.AddAsync(servizio);
                return RedirectToAction(nameof(Index));
            }
            return View(servizio);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var servizio = await _servizioDao.GetByIdAsync(id);
            if (servizio == null)
            {
                return NotFound();
            }
            return View(servizio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AdditionalService servizio)
        {
            if (id != servizio.ServiceID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _servizioDao.UpdateAsync(servizio);
                return RedirectToAction(nameof(Index));
            }
            return View(servizio);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var servizio = await _servizioDao.GetByIdAsync(id);
            if (servizio == null)
            {
                return NotFound();
            }
            return View(servizio);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _servizioDao.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
