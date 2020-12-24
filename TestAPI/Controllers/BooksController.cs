using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Controllers {

  [ApiController]
  [Route("api/users/{userId}/books")]
  public class BooksController : ControllerBase {

    [HttpGet]
    public IActionResult GetUserBooks(int userId) {
      var user = UsersDataStore.Current.Users.FirstOrDefault(u => u.Id == userId);
      if (user == null) return NotFound();
      return Ok(user.Books);
    }

    [HttpGet("{bookId}", Name = "GetBookById")]
    public IActionResult GetBookById(int userId, int bookId) {
      var user = UsersDataStore.Current.Users.FirstOrDefault(u => u.Id == userId);
      if (user == null) return NotFound();
      var book = user.Books.FirstOrDefault(b => b.Id == bookId);
      if (book == null) return NotFound();
      return Ok(book);
    }

    //not working
    [HttpPost]
    public IActionResult CreateBook(int userId, [FromBody] BookForCreation bookForCreation) {
      var user = UsersDataStore.Current.Users.FirstOrDefault(u => u.Id == userId);
      if (user == null) return NotFound();
      var maxId = UsersDataStore.Current.Users.SelectMany(u => u.Books).Max(b => b.Id);
      Book finalBook = new Book() {
        Id = ++maxId,
        Title = bookForCreation.Title,
        Author = bookForCreation.Author,
        Genres = bookForCreation.Genres
      };

      user.Books.Add(finalBook);
      return CreatedAtRoute("GetBookById", new { userId, finalBook.Id }, finalBook);
    }
  }
}