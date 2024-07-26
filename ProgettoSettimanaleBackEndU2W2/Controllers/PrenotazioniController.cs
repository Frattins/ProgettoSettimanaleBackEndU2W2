using Microsoft.AspNetCore.Mvc;
using ProgettoSettimanaleBackEndU2W2.DAO;
using ProgettoSettimanaleBackEndU2W2.Models;
using System.Threading.Tasks;

namespace ProgettoSettimanaleBackEndU2W2.Controllers
{
    public class PrenotazioniController : Controller
    {
        private readonly IPrenotazioneDao _prenotazioneDao;

        public PrenotazioniController(IPrenotazioneDao prenotazioneDao)
        {
            _prenotazioneDao = prenotazioneDao;
        }

        public async Task<IActionResult> Index()
        {
            var reservations = await _prenotazioneDao.GetAllAsync();
            return View(reservations);
        }

        public async Task<IActionResult> Details(int id)
        {
            var reservation = await _prenotazioneDao.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                await _prenotazioneDao.AddAsync(reservation);
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var reservation = await _prenotazioneDao.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reservation reservation)
        {
            if (id != reservation.ReservationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _prenotazioneDao.UpdateAsync(reservation);
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var reservation = await _prenotazioneDao.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _prenotazioneDao.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
