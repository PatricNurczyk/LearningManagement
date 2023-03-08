using Library.Project_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Project_2.Models
{
    public class TA : Person
    {
        public TA() 
        {
            this.ID = ++lastID;
            Name = string.Empty;
            Classification= string.Empty;
            CourseTaken = new List<Course>();
        }
    }
}
