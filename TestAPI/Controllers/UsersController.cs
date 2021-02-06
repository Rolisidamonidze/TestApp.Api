using Dapper;
using TestAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace TestAPI.Controllers {

  [ApiController]
  [Route("api/users")]
  public class UsersController : ControllerBase {
    private readonly string connectionString = @"Server=DESKTOP-7V4DP48\SQLEXPRESS;Database=Test;Trusted_Connection=True";

    [HttpGet]
    public IActionResult GetAllUsers() {
      const string command = "select * from Users";
      using (SqlConnection connection = new SqlConnection(connectionString)) {
        return Ok(connection.Query<User>(command));
      }
    }

    [HttpGet("active")]
    public IActionResult GetActiveUsers() {
      const string command = "select * from Users where IsActive = 1";
      using (SqlConnection connection = new SqlConnection(connectionString)) {
        return Ok(connection.Query<User>(command));
      }
    }

    [HttpGet("{id}", Name = "GetUserByID")]
    public IActionResult GetUser(int id) {
      string command = $"select * from Users where ID = {id}";
      using (SqlConnection connection = new SqlConnection(connectionString)) {
        return Ok(connection.QueryFirstOrDefault<User>(command));
      }
    }

    [HttpPost]
    public int AddUser([FromBody] UserForCreation user) {
      string command = "insert into Users(Firstname, Lastname, Age, Gender, About, IsActive, IsEmployed)";
      command += $"values (@Firstname, @Lastname, @Age, @Gender, @About, @IsActive, @IsEmployed)";
      using (SqlConnection connection = new SqlConnection(connectionString)) {
        return connection.Execute(command, user);
      }
    }

    [HttpPut("{id}")]
    public int UpdateUser(int id, [FromBody] UserForUpdate user) {
      string command = $"update Users set Firstname=@Firstname, Lastname=@Lastname, Age=@Age, Gender=@Gender, About=@About, IsActive=@IsActive, IsEmployed=@IsEmployed where ID={id}";
      using (SqlConnection connection = new SqlConnection(connectionString)) {
        return connection.Execute(command, user);
      }
    }
  }
}