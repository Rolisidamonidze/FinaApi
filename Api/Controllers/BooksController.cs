using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Controllers {

  [ApiController]
  [Route("api/users/{userId}/books")]
  public class BooksController : ControllerBase {
    private Context _context { get; }

    public BooksController(Context context) {
      _context = context;
    }

    [HttpGet]
    public IActionResult GetUserBooks(int userId) {
      var user = _context.Users.Where(user => user.UserID == userId)
        .Include(user => user.Books).FirstOrDefault();
      return Ok(user.Books.ToList());
    }

    [HttpGet]

    public int GetUserBooksCount(int userId)
    {
      var user = _context.Users.Where(user => user.UserID == userId)
        .Include(user => user.Books).FirstOrDefault();
      return user.Books.Count;
    }

    [HttpPost]
    public int AddBookToUser(int userId, Book book) {
      var targetUser = _context.Users.FirstOrDefault(user => user.UserID.Equals(userId));
      if (targetUser == null)
      {
        return -1;
      }
      targetUser.Books.Add(book);
      _context.SaveChanges();
      return book.BookID;
    }
  }
}