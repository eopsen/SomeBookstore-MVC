using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class BooksController : Controller
    {
        private readonly IBooksService _service;

        public BooksController(IBooksService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var books = await _service.GetAllAsync();
            return View(books.OrderByDescending(b =>b.ReleaseDate).ToList());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allBooks = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                var filteredResultNew = allBooks.Where(n => n.Name.ToLower().IndexOf(searchString) >= 0).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allBooks);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var detail = await _service.GetByIdAsync(id);
            return View(detail);
        }
                
        public async Task<IActionResult> Create()
        {
            var dropdownsData = await _service.GetNewBookDropdownsValues();

            ViewBag.Authors = new SelectList(dropdownsData.Authors, "Id", "FullName");
            ViewBag.Publishers = new SelectList(dropdownsData.Publishers, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                var dropdownsData = await _service.GetNewBookDropdownsValues();

                ViewBag.Authors = new SelectList(dropdownsData.Authors, "Id", "FullName");
                ViewBag.Publishers = new SelectList(dropdownsData.Publishers, "Id", "Name");

                return View(book);
            }

            await _service.AddNewBookAsync(book);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var book = await _service.GetByIdAsync(id);
            if (book == null) return View("NotFound");

            var response = new BookViewModel()
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                Price = book.Price,
                AuthorId = book.AuthorId,
                PublisherId = book.PublisherId,
                ImageURL = book.ImageUrl,
                BookCategory = book.BookCategory,
                ReleaseDate = book.ReleaseDate
            };

            var dropdownsData = await _service.GetNewBookDropdownsValues();
            ViewBag.Authors = new SelectList(dropdownsData.Authors, "Id", "FullName");
            ViewBag.Publishers = new SelectList(dropdownsData.Publishers, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BookViewModel book)
        {
            if (id != book.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var dropdownsData = await _service.GetNewBookDropdownsValues();
                ViewBag.Authors = new SelectList(dropdownsData.Authors, "Id", "FullName");
                ViewBag.Publishers = new SelectList(dropdownsData.Publishers, "Id", "Name");

                return View(book);
            }

            await _service.UpdateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }
    }
}
