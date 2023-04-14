using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetStandard.LearningMangement.Models
{
    public class Module
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ContentItem> ContentItems { get; set; }

        public Module() 
        {
            Name = string.Empty;
            Description = string.Empty;
            ContentItems = new List<ContentItem>();
        }

        public override string ToString()
        {
            /*string s = $"{Name} - {Description}\n";
            for(int i = 0; i < ContentItems.Count; ++i)
            {
                if (ContentItems[i].GetType() == typeof(PageItem))
                {
                    PageItem p = (PageItem)ContentItems[i];
                    s += $"{p.Name} - {p.Description} - Page\n";
                    s += p.HTMLBody + "\n";
                }
                else if (ContentItems[i].GetType() == typeof(FileItem))
                {
                    FileItem f = (FileItem)ContentItems[i];
                    s += $"{f.Name} - {f.Description} - File\n";
                    s += f.FilePath + "\n";
                }
                else if (ContentItems[i].GetType() == typeof(AssignmentItem))
                {
                    AssignmentItem a = (AssignmentItem)ContentItems[i];
                    s += $"{a.Name} - {a.Description} - Assignment\n";
                    s += a.assignmentItem.ToString() + "\n";
                }
            } */
            return Name;
        }
    }
}
