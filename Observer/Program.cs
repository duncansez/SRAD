using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {        
        static void Main(string[] args)
        {
            var db = new db_SRADEntities();
            Console.WriteLine("Reading from grade record");
            var grade = db.Grades.Where(d => d.isNotify == false).ToList();
            foreach(var item in grade)
            {
                Console.WriteLine("Notify user");
                //send email or other notification

                //insert log
                var log = new Log();
                log.Grade = item;
                log.Message = "Holla, your grade has been updated in the SRAD platform. Please login to your account to check your result";

                log.DateModified = DateTime.Now;
                log.UserModified = "Observer";

                log.DateCreated = DateTime.Now;
                log.UserCreated = "Observer";

                //update grade state status to notified, so the observer engine will skip this record
                item.isNotify = true;

                db.Logs.Add(log);
                db.SaveChanges();
            }
            Console.WriteLine("Checking completed");
        }
    }
}
