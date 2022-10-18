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
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }
		[AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allproducers= await _service.GetAllAsync();
            return View(allproducers);
        }
		//GET: Producers/details/1=id
		[AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producersDetails = await _service.GetByIdAsync(id);
            if (producersDetails==null)
            {
                return View("NotFound");
            }
            else
            {
                return View(producersDetails);
            }
        }
        //GET: Producers/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureUrl", "FullName", "Bio")]Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            else
            {
                await _service.AddAsync(producer);
            }
            return RedirectToAction(nameof(Index));
        }
        //GET: Producers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails==null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePictureUrl", "FullName", "Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if(id==producer.Id)
            {
                await _service.UpdateAsync(id,producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }
        // Get request: /Producers/delete/1=id
        public async Task<IActionResult> Delete(int id)
        {
            var producersDetails = await _service.GetByIdAsync(id);
            if (producersDetails==null)
            {
                return View("NotFound");
            }
            return View(producersDetails);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producersDetails=await _service.GetByIdAsync(id);
            if (producersDetails==null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
