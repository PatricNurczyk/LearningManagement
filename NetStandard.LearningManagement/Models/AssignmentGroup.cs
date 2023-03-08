using NetStandard.LearningMangement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStandard.LearningMangement.Models
{
    public class AssignmentGroup
    {
        public string Name { get; set; }
        public float Percentage { get; set; }
        public List<Assignment> Assign { get; set; }

        public float totalPoints { get; set; }

        public AssignmentGroup()
        {
            Name= string.Empty;
            Percentage= 0;
            totalPoints= 0;
            Assign = new List<Assignment>();
        }


        public override string ToString()
        {
            string s = $"{Name} - {Percentage * 100}%\n";
            foreach (Assignment item in Assign) 
            {
                s += "    " + item.ToString() + "\n";
            }
            return s;
        }
    }
}
