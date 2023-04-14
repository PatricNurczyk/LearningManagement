using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStandard.LearningMangement.Models
{
    public class Grades
    {
        public int creditHours { get; set; }
        public Dictionary<AssignmentGroup, float> Points { get; set; }
        public float Grade { get; set; }

        public Grades(Course c) 
        {
            creditHours = c.creditHours;
            Points = new Dictionary<AssignmentGroup, float>();
            foreach(AssignmentGroup group in c.Assignments)
            {
                Points.Add(group, 0);
            }
            Grade = 0;
        }
    }
}
