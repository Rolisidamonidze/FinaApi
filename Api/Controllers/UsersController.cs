using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Api.Models;
using Api.Contexts;

namespace Api.Controllers {

  [ApiController]
  [Route("api/users")]
  public class UsersController : ControllerBase {
    private Context _context { get; }

    public UsersController(Context context) {
      _context = context;
    }

    [HttpGet]
    public List<User> GetAllUsers() {
      return _context.Users.ToList();
    }

    [HttpGet("active")]
    public List<User> GetActiveUser()
    {
      return _context.Users.Where(user => user.IsActive == true).ToList();
    }

    [HttpGet("{id}")]
    public List<User> GetUserByID(int id) {
      return _context.Users.Where(user => user.UserID.Equals(id)).ToList();
    }

    [HttpPost]
    public int AddUser(User user) {
      if (_context == null) {
        return -1;
      }
      _context.Users.Add(user);
      _context.SaveChanges();
      return user.UserID;
    }

    [HttpDelete("{id}")]
    public int RemoveUser(int id) {
      if (_context == null) {
        return -1;
      }
      _context.Users.Remove(_context.Users.FirstOrDefault(user => user.UserID == id));
      _context.SaveChanges();
      return 0;
    }
  }
}