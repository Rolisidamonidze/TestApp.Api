using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models {

  public class BookForCreation {
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genres { get; set; }
  }
}