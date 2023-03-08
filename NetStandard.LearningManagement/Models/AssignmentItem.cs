using Library.Project_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Project_2.Models
{
    public class AssignmentItem : ContentItem
    {

        public Assignment assignmentItem { get; set; }

        public override string ToString()
        {
            string s = $"{Name} - {Description} - Assignment\n"; 
            s += assignmentItem.ToString();
            return s;
        }
    }
}
