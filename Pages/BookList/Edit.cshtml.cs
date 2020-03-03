using System.Threading.Tasks;
using BookKeeper.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookKeeper
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        [BindProperty]
        public Book Book { get; set; }

        //post handler
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var bookFromDb = await _db.Book.FindAsync(Book.Id);
                bookFromDb.Name = Book.Name;
                bookFromDb.Author = Book.Author;
                bookFromDb.Isbn = Book.Isbn;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();

        }
    }
}