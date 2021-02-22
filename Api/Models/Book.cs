using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models {

  [Description("This is Books' Table")]
  public class Book {

    [Description("This is Book ID")]
    public int BookID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
  }
}