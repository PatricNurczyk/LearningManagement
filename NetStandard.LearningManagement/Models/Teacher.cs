using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStandard.LearningMangement.Models
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
