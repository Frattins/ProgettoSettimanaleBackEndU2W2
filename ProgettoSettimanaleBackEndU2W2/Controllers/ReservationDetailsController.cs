using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgettoSettimanaleBackEndU2W2.Interfaces;
using ProgettoSettimanaleBackEndU2W2.Models;

namespace ProgettoSettimanaleBackEndU2W2.Controllers
{
    [Authorize]
    public class ReservationDetailsController : Controller
    {
        private readonly IReservationDetailRepository _reservationDetailRepository;

        public ReservationDetailsController(IReservationDetailRepository reservationDetailRepository)
        {
            _reservationDetailRepository = reservationDetailRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _reservationDetailRepository.GetAllReservationDetails());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationID,RoomNumber,Period,RateApplied,AdditionalServicesList,TotalAmountToPay")] ReservationDetail reservationDetail)
        {
            if (ModelState.IsValid)
            {
                await _reservationDetailRepository.AddReservationDetail(reservationDetail);
                return RedirectToAction(nameof(Index));
            }
            return View(reservationDetail);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var reservationDetail = await _reservationDetailRepository.GetReservationDetailById(id);
            if (reservationDetail == null)
            {
                return NotFound();
            }
            return View(reservationDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetailID,ReservationID,RoomNumber,Period,RateApplied,AdditionalServicesList,TotalAmountToPay")] ReservationDetail reservationDetail)
        {
            if (id != reservationDetail.DetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _reservationDetailRepository.UpdateReservationDetail(reservationDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationDetailExists(reservationDetail.DetailID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reservationDetail);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var reservationDetail = await _reservationDetailRepository.GetReservationDetailById(id);
            if (reservationDetail == null)
            {
                return NotFound();
            }

            return View(reservationDetail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _reservationDetailRepository.DeleteReservationDetail(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationDetailExists(int id)
        {
            return _reservationDetailRepository.GetReservationDetailById(id) != null;
        }
    }
}
