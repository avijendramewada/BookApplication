using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstApp.Model;

namespace MyFirstApp.Pages.BookList
{
    public class EditModel : PageModel
    {
        private  ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Books { get; set; }
        public async Task OnGet(int id)
        {
            Books = await _db.Book.FindAsync(id);

        }
        public async Task<IActionResult> OnPost() {
            if (ModelState.IsValid)
            {
                var BookFormDb = await _db.Book.FindAsync(Books.Id);
                BookFormDb.Name = Books.Name;
                BookFormDb.Author = Books.Author;
                BookFormDb.ISBN = Books.ISBN;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");


            }
            return RedirectToPage();
        }
        
}
}