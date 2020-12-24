using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI {

  public class UsersDataStore {
    public static UsersDataStore Current { get; } = new UsersDataStore();
    public List<User> Users { get; set; }

    public UsersDataStore() {
      Users = new List<User>() {
         new User(){
           Id = 1,
           Firstname = "Giorgi",
           Lastname = "Giorgadze",
           Books = new List<Book>() {
             new Book() {
               Id = 1,
               Title = "Norwegian Wood",
               Author = "Haruki Murakami",
               Genres = "Romance novel"
             },
             new Book() {
               Id = 2,
               Title = "Steppenwolf",
               Author = "Hermann Hesse",
               Genres = "Romance novel"
             }
           }
         },
         new User() {Id = 2, Firstname = "Davit", Lastname = "Davitishvili"},
         new User() {Id = 3, Firstname = "Vakhtang", Lastname = "Vakhtangishvili"}
      };
    }
  }
}