using System.Linq;
using System.Threading.Tasks;
using BookKeeper.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace BookKeeper.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task< IActionResult> GetAll()
        {
            return Json(new {data =await _db.Book.ToListAsync()});
        }

        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (bookFromDb == null)
            {
                return Json(new {success = false, message = "Error when deleting"});
            }

            _db.Book.Remove(bookFromDb);
            await _db.SaveChangesAsync();
            return Json(new {success = true, message = "delete successful"});
        }


    }
}