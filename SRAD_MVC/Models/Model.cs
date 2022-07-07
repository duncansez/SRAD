using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRAD_MVC.Models
{
    public class UserType : BaseEntity
    {
        public string Type { get; set; }
    }
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public string UserType { get; set; }
    }
    public class Admin : BaseEntity
    {
        public string StaffNo { get; set; }
        public User User { get; set; }
    }
    public class Student : BaseEntity
    {
        public string MatrixNo { get; set; }
        public User User { get; set; }
        public List<Course> Course { get; set; }
    }
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Section { get; set; }
        public int CreditHours { get; set; }
    }
    public class Grade : BaseEntity
    {
        public string Course { get; set; }
        public string User { get; set; }
        public double Score { get; set; }
        public bool isNotify { get; set; }
    }
    public class Log : BaseEntity
    {
        public Grade Grade { get; set; }
        public string Message { get; set; }
    }
}