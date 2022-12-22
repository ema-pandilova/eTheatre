using eTheatre.Data;
using eTheatre.Data.Services;
using eTheatre.Data.Static;
using eTheatre.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTheatre.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class TheatresController : Controller
    {
        private readonly ITheatresService _service;
        public TheatresController(ITheatresService service)
        {
            _service = service;

        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allTheatres = await _service.GetAllAsync();
            return View(allTheatres);
        }
       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Theatre theatre)
        {
            if (!ModelState.IsValid) return View(theatre);
            await _service.AddAsync(theatre);
            return RedirectToAction(nameof(Index));
        }

      
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var theatreDetails = await _service.GetByIdAsync(id);
            if (theatreDetails == null) return View("NotFound");
            return View(theatreDetails);
        }

        //Get: 
        public async Task<IActionResult> Edit(int id)
        {
            var theatreDetails = await _service.GetByIdAsync(id);
            if (theatreDetails == null) return View("NotFound");
            return View(theatreDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Theatre theatre)
        {
            if (!ModelState.IsValid) return View(theatre);
            await _service.UpdateAsync(id, theatre);
            return RedirectToAction(nameof(Index));
        }

        //Get: Theatres/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var theatreDetails = await _service.GetByIdAsync(id);
            if (theatreDetails == null) return View("NotFound");
            return View(theatreDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var theatreDetails = await _service.GetByIdAsync(id);
            if (theatreDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
