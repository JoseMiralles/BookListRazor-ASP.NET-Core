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

        public Book Book { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            this._db = db;
        }

        public void OnGet()
        {

        }
        public void OnPost()
        {

        }

    }
}
