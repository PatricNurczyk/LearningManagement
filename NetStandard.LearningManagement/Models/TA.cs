using NetStandard.LearningMangement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStandard.LearningMangement.Models
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
