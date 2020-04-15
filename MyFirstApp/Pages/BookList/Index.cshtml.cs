using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyFirstApp.Model;

namespace MyFirstApp.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var Book = await _db.Book.FindAsync(id);
            if (Book == null)
            {
                return NotFound();
            }
            _db.Book.Remove(Book);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}