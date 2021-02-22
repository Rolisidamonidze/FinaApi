using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models {

  public class User {
    public int UserID { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public bool IsActive { get; set; } = true;
    public List<Book> Books { get; set; } = new List<Book>();
  }
}