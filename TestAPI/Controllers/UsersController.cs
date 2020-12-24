using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Controllers {

  [ApiController]
  [Route("api/users")]
  public class UsersController : ControllerBase {

    [HttpGet]
    public IActionResult GetAllUsers() {
      return Ok(UsersDataStore.Current.Users);
    }

    [HttpGet("{id}", Name = "GetUserByID")]
    public IActionResult GetUser(int id) {
      var userToReturn = UsersDataStore.Current.Users.FirstOrDefault(user => user.Id == id);
      if (userToReturn == null) return NotFound();
      return Ok(userToReturn);
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] UserForCreation user) {
      var maxId = UsersDataStore.Current.Users.Max(u => u.Id);
      User finalUser = new User() {
        Id = ++maxId,
        Firstname = user.Firstname,
        Lastname = user.Lastname,
        Books = user.Books
      };
      UsersDataStore.Current.Users.Add(finalUser);
      return CreatedAtRoute("GetUserByID", new { finalUser.Id }, finalUser);
    }
  }
}