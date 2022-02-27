using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SomeBookstore.Data;
using SomeBookstore.Data.Services;
using SomeBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomeBookstore.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PublishersController : Controller
    {
        private readonly IPublishersService _service;

        public PublishersController(IPublishersService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var authors = await _service.GetAllAsync();
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ImageUrl,Name,Description")] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }

            await _service.AddAsync(publisher);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null) return View("NotFound");
            return View(entity);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null) return View("NotFound");
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageUrl,Name,Description")] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }

            await _service.UpdateAsync(id, publisher);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null) return View("NotFound");
            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
