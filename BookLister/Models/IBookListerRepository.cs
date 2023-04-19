using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLister.Models
{
    public interface IBookListerRepository
    {
        IQueryable<Book> Books { get; }
        void SaveChanges();
        void Remove(Book book);

    }
}
