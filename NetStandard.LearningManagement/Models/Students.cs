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

        public List<Grades> Grades { get; set; }

        public Students() 
        {
            this.ID = ++lastID;
            Name = string.Empty;
            Classification= string.Empty;
            CourseTaken = new List<Course>();
            GPA=0;
            Grades = new List<Grades>();
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
