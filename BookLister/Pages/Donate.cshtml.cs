using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookLister.Models;
using BookLister.Infastructure;

namespace BookLister.Pages
{
    public class DonateModel : PageModel
    {
        private IBookListerRepository repo { get; set; }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }


        public DonateModel (IBookListerRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookid);
      
            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl } );
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);
            
            return RedirectToPage( new {ReturnUrl = returnUrl});
        }
    }
}
