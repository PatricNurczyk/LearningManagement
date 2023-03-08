using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Project_2.Models
{
    public class Teacher : Person
    {
        public Teacher() 
        {
            this.ID = ++lastID;
            Name= string.Empty;
            Classification = "Teacher";
            CourseTaken = new List<Course>();
        }
    }
}
