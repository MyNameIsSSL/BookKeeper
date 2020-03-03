using System.Collections.Generic;
using System.Threading.Tasks;
using BookKeeper.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookKeeper
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public  IEnumerable<Book> Books { get; set; }


        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }
    }
}