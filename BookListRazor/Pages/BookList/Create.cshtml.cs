using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        [BindProperty] //This makes it an alternative to passing a Book object in the Post and Get methods.
        public Book Book { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            this._db = db;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) //True if the required fields are filled (ex: Book.Name is required).
            {
                await this._db.Book.AddAsync(this.Book); //Add book to queue
                await this._db.SaveChangesAsync(); //Apply changes from the queue
                return RedirectToPage("Index"); //Return to BookList/Index
            }
            else
            {
                return Page();
            }
        }

    }
}
