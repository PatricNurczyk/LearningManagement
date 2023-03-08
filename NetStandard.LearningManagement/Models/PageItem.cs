using NetStandard.LearningMangement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NetStandard.LearningMangement.Models
{
    public class PageItem : ContentItem
    { 
        public string HTMLBody { get; set; }


        public override string ToString()
        {
            string s = $"{Name} - {Description} - Page\n";
            s += HTMLBody;
            return s;
        }
    }
}
