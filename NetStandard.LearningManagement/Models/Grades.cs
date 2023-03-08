using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Project_2.Models
{
    public class Grades
    {
        public int creditHours { get; set; }
        public Dictionary<AssignmentGroup, float> Points { get; set; }
        public float Grade { get; set; }

        public Grades() 
        {
            creditHours= 0;
            Points = new Dictionary<AssignmentGroup, float>();
            Grade = 0;
        }
    }
}
