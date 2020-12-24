using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models {

  public class User {
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int NumberOfBooks => Books.Count;
    public ICollection<Book> Books { get; set; } = new List<Book>();
  }
}