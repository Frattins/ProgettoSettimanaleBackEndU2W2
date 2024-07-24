using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgettoSettimanaleBackEndU2W2.Interfaces;
using ProgettoSettimanaleBackEndU2W2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ProgettoSettimanaleBackEndU2W2.Controllers
{
    [Authorize]
    public class AdditionalServicesController : Controller
    {
        private readonly IAdditionalServiceRepository _additionalServiceRepository;

        public AdditionalServicesController(IAdditionalServiceRepository additionalServiceRepository)
        {
            _additionalServiceRepository = additionalServiceRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _additionalServiceRepository.GetAllAdditionalServices());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationID,ServiceName,ServiceDate,Quantity,Price")] AdditionalService additionalService)
        {
            if (ModelState.IsValid)
            {
                await _additionalServiceRepository.AddAdditionalService(additionalService);
                return RedirectToAction(nameof(Index));
            }
            return View(additionalService);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var additionalService = await _additionalServiceRepository.GetAdditionalServiceById(id);
            if (additionalService == null)
            {
                return NotFound();
            }
            return View(additionalService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceID,ReservationID,ServiceName,ServiceDate,Quantity,Price")] AdditionalService additionalService)
        {
            if (id != additionalService.ServiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _additionalServiceRepository.UpdateAdditionalService(additionalService);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdditionalServiceExists(additionalService.ServiceID))
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
            return View(additionalService);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var additionalService = await _additionalServiceRepository.GetAdditionalServiceById(id);
            if (additionalService == null)
            {
                return NotFound();
            }

            return View(additionalService);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _additionalServiceRepository.DeleteAdditionalService(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AdditionalServiceExists(int id)
        {
            return _additionalServiceRepository.GetAdditionalServiceById(id) != null;
        }
    }
}
