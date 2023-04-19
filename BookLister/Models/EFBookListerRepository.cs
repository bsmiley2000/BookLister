using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLister.Models
{
    public class EFBookListerRepository : IBookListerRepository
    {

        private bookstoreContext context { get; set; }

        public EFBookListerRepository (bookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
