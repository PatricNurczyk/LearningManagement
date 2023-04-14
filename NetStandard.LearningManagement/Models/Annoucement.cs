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

        public Annoucement(string s)
        {
            Heading = s;
            Content = s;
        }

        public Annoucement() 
        {
            Heading = string.Empty;
            Content = string.Empty;
        }
        public override string ToString()
        {
            return Heading;             
        }
    }
}
