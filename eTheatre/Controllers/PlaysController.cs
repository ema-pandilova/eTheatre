using eTheatre.Data;
using eTheatre.Data.Services;
using eTheatre.Data.Static;
using eTheatre.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eTheatre.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PlaysController : Controller
    {
        private readonly IPlaysService _service;
        public PlaysController(IPlaysService service)
        {
            _service = service;

        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Theatre);
            return View(allMovies);
        }


        public async Task<IActionResult> Filter(string searchString)
        {
            var allPlays = await _service.GetAllAsync(n => n.Theatre);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allPlays.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                //var filteredResultNew = allPlays.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResult);
            }

            return View("Index", allPlays);
        }

        //GET: Plays/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var playDetail = await _service.GetPlayByIdAsync(id);
            return View(playDetail);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewPlayDropdownsValues();

            ViewBag.Theatres = new SelectList(movieDropdownsData.Theatres, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPlayVM play)
        {
            if (!ModelState.IsValid)
            {
                var playDropdownsData = await _service.GetNewPlayDropdownsValues();

                ViewBag.Cinemas = new SelectList(playDropdownsData.Theatres, "Id", "Name");
                ViewBag.Producers = new SelectList(playDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(playDropdownsData.Actors, "Id", "FullName");

                return View(play);
            }

            await _service.AddNewPlayAsync(play);
            return RedirectToAction(nameof(Index));
        }

        //GET: Plays/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var playDetails = await _service.GetPlayByIdAsync(id);
            if (playDetails == null) return View("NotFound");

            var response = new NewPlayVM()
            {
                Id = playDetails.Id,
                Name = playDetails.Name,
                Description = playDetails.Description,
                Price = playDetails.Price,
                StartDate = playDetails.StartDate,
                EndDate = playDetails.EndDate,
                ImageURL = playDetails.ImageURL,
                PlayCategory = playDetails.PlayCategory,
                TheatreId = playDetails.TheatreId,
                ProducerId = playDetails.ProducerId,
                ActorIds = playDetails.Actors_Plays.Select(n => n.ActorId).ToList(),
            };

            var playDropdownsData = await _service.GetNewPlayDropdownsValues();
            ViewBag.Theatres = new SelectList(playDropdownsData.Theatres, "Id", "Name");
            ViewBag.Producers = new SelectList(playDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(playDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewPlayVM play)
        {
            if (id != play.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var playDropdownsData = await _service.GetNewPlayDropdownsValues();

                ViewBag.Cinemas = new SelectList(playDropdownsData.Theatres, "Id", "Name");
                ViewBag.Producers = new SelectList(playDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(playDropdownsData.Actors, "Id", "FullName");

                return View(play);
            }

            await _service.UpdatePlayAsync(play);
            return RedirectToAction(nameof(Index));
        }


    }
}
