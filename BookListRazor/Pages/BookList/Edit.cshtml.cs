using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {

        private ApplicationDbContext _db;

        [BindProperty] //Bindthis property to the view.
        public Book Book { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) //Check if the form is valid.
            {
                var BookFromDb = await this._db.Book.FindAsync(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.Author = Book.Author;
                BookFromDb.ISBN = Book.ISBN;

                await this._db.SaveChangesAsync(); //Saves the changes from above.

                return RedirectToPage("Index"); //Return to BookList/Index
            }
            return RedirectToPage();
        }

    }
}
