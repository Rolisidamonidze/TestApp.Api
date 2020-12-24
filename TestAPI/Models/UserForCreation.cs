using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models {

  public class UserForCreation {
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
  }
}