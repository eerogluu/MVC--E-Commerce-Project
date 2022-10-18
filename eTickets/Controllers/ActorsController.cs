using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
		[AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GetAllAsync();
            return View(allActors);
        }
        // Get request: /Actors/Create
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName","ProfilePictureUrl","Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return  View(actor);
            }
            else
            {
               await _service.AddAsync(actor);
            }
            return RedirectToAction(nameof(Index));
        }
		// Get: Actors/Details/ActorId=1
		[AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails==null)
            {
                return View("NotFound");
            }
            else
            {
                return View(actorDetails);
            }
        }
        // Get request: /Actors/Edit/1
       
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName", "ProfilePictureUrl", "Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            else
            {
                await _service.UpdateAsync(id,actor);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> EditAsync(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }
        // Get request: /Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
           
            return RedirectToAction(nameof(Index));
        }
    }
}
