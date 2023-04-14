using NetStandard.LearningMangement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStandard.LearningMangement.Models
{
    public class Students : Person
    {
        public float GPA { get; set; }

        public Dictionary<string, Grades> Grades { get; set; }

        public Students() 
        {
            this.ID = ++lastID;
            Name = string.Empty;
            Classification= string.Empty;
            CourseTaking = new List<Course>();
            GPA=0;
            Grades = new Dictionary<string, Grades>();
            
        }

       /* public override string ToString()
        {
            string s = $"ID: {ID}| Name: {Name}| Classification: {Classification}| GPA: {GPA} \n";
            s += "Courses Taking: \n";
            for(int i = 0; i < CourseTaken.Count; ++i)
            {
                s += $"{CourseTaken[i].Code} - {CourseTaken[i].Name} - Grade: {Grades[i].Grade}\n";
            }
            return s;
        } */
    }
}
