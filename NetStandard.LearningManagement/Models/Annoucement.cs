using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStandard.LearningMangement.Models
{
    public class Annoucement
    {
        public string Heading { get; set; }
        public string Content { get; set; }


        public override string ToString()
        {
            string s = $"{Heading}\n";
            s += "-------------\n";
            s += Content;
            return s;
                       
        }
    }
}
