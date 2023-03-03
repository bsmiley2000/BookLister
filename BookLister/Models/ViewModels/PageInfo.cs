using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLister.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }

        public int BooksPerPage { get; set; }

        public int CurrentPage { get; set; }


        // Figure out how many pages we need
        public int TotalBooks => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);

    }
}
