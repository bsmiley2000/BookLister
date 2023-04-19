using BookLister.Models;
using BookLister.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookLister.Controllers
{
    public class HomeController : Controller
    {
        private IBookListerRepository repo { get; set; }

        public HomeController (IBookListerRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookType, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(p => p.Category == bookType || bookType == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookType == null
                    ? repo.Books.Count()
                    : repo.Books.Where(x => x.Category == bookType).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

        [HttpGet]
        public IActionResult Edit (int bookid)
        {
            ViewBag.Books = repo.Books.ToList();

            var book = repo.Books.FirstOrDefault(x => x.BookId == bookid);

            return View("BookEdit", book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
               /* repo.Books(book);*/
             
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Books = repo.Books.ToList();
                return RedirectToAction("BookEdit");
            }
        }
    }
}
