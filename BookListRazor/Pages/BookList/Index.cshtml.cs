using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {

        /// <summary>
        /// Contains an instance of the db.
        /// </summary>
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {
            //Store books from DB as a list.
            this.Books = await _db.Book.ToListAsync();
            //01:20:00
        }
    }
}
