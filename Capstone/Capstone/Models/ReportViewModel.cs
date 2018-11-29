using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
   
    public class ReportViewModel
    {
        

        public List<Student> studentList;
        public string id { set; get; }
        public int studentID { set; get; }
    }
}