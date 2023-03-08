using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStandard.LearningMangement.Models
{
    public class Assignment
    {
        private string name;
        private string description;
        public string Name
        {
            get { return name; }
            set { name = value ?? "N/A"; }
        }
        public string Description 
        {
            get { return description; }
            set { description = value ?? "N/A"; }
        }
        public int TotalAvailablePoints
        {
            get;
            set;
        }

        public DateTime DueDate
        {
            get;
            set;
        }

        public Assignment()
        {
            name = "N/A";
            description= string.Empty;
            TotalAvailablePoints = 0;
            DueDate= DateTime.MinValue;
        }

        public override string ToString()
        {
            return $"- Name: {Name}| Description: {Description}| Points: {TotalAvailablePoints}| DueDate: {DueDate}";
        }
    }
}
