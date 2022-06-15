using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRAD_MVC.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }
        public bool? IsDeleted { get; set; }
    }
}