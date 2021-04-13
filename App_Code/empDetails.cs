using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class empDetails
{
    public int id { get; set; }
    public string empid { get; set; }
    public string Password { get; set; }
    public string Fname { get; set; }
    public string Mname { get; set; }
    public string Lname { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string[] Roles { get; set; }
    public string Rolename { get; set; }
    public int Role { get; set; }
    public bool Active { get; set; }
    public DateTime dateupdated { get; set; }
}
