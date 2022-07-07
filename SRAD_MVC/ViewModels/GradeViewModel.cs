using SRAD_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRAD_MVC.ViewModels
{
    public class GradeViewModel : BaseEntity
    {
        public string Course { get; set; }
        public string User { get; set; }
        public double Score { get; set; }
        public string Result { get; set; }
        public string Grade { get; set; }
    }
}