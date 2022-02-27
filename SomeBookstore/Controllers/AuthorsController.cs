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
    public class AuthorsController : Controller
    {
        private readonly IAuthorsService _service;

        public AuthorsController(IAuthorsService service)
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
        public async Task<IActionResult> Create([Bind("ImageUrl,FullName,Description")] Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            await _service.AddAsync(author);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageUrl,FullName,Description")] Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            await _service.UpdateAsync(id, author);
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
