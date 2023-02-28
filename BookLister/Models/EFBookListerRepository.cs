using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLister.Models
{
    public class EFBookListerRepository : IBookListerRepository
    {

        private BookstoreContext context { get; set; }

        public EFBookListerRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
