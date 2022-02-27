using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ReviewsController : Controller
    {
        private readonly IReviewsService _service;
        private readonly IBooksService _bookService;

        public ReviewsController(IReviewsService service, IBooksService bookService)
        {
            _service = service;
            _bookService = bookService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            var booksList = await _bookService.GetAllAsync();
            ViewBag.Books = new SelectList(booksList, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("BookId,ReviewerName,Text,Rating")] Review review)
        {
            if (!ModelState.IsValid)
            {
                return View(review);
            }

            await _service.AddAsync(review);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var booksList = await _bookService.GetAllAsync();
            ViewBag.Books = new SelectList(booksList, "Id", "Name");

            var reviewDetails = await _service.GetByIdAsync(id);
            if (reviewDetails == null) return View("NotFound");
            return View(reviewDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var booksList = await _bookService.GetAllAsync();
            ViewBag.Books = new SelectList(booksList, "Id", "Name");

            var reviewDetails = await _service.GetByIdAsync(id);
            if (reviewDetails == null) return View("NotFound");
            return View(reviewDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,ReviewerName,Text,Rating")] Review review)
        {
            if (!ModelState.IsValid)
            {
                return View(review);
            }

            await _service.UpdateAsync(id, review);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var booksList = await _bookService.GetAllAsync();
            ViewBag.Books = new SelectList(booksList, "Id", "Name");

            var reviewDetails = await _service.GetByIdAsync(id);
            if (reviewDetails == null) return View("NotFound");
            return View(reviewDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviewDetails = await _service.GetByIdAsync(id);
            if (reviewDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
