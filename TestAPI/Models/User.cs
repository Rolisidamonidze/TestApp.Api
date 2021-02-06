using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models {

  public class User {
    public int Id { get; set; }
    public bool IsActive { get; set; } = true;
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string About { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public bool IsEmployed { get; set; }
  }
}