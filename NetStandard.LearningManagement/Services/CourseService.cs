using NetStandard.LearningMangement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStandard.LearningMangement.Services
{
    public class CourseService
    {
        private static CourseService instance;
        public static string Codes {  get; private set; }

        public static CourseService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new CourseService();
                }
                return instance;
            }
        }
        public List<Course> Courses { get; set; }

        private CourseService()
        {
            Codes = string.Empty;
            Courses = new List<Course>();
            Course c = new Course();
            c.Name = "TestCourse";
            c.Code = "COP1234";
            c.Description = "This is a Description of a Course";
            c.Annoucements.Add(new Annoucement("Welcome to the Course"));
            Module m = new Module();
            m.Name = "Module 0: Welcome";
            m.Description = "This is the Welcome Module";
            PageItem page = new PageItem();
            page.Name = "Welcome";
            page.HTMLBody = "<body>WELCOME<body>";
            m.ContentItems.Add(page);
            c.Modules.Add(m);
            Courses.Add(c);
        }

        public void AddCourse(Course c)
        {
            Codes += c.Code;
            Courses.Add(c);
        }

        public void AddAssignment(Course c, Assignment a, string selectedAssignment)
        {
            foreach(AssignmentGroup assign in c.Assignments)
            {
                if (assign.Name == selectedAssignment)
                {
                    assign.totalPoints += a.TotalAvailablePoints;
                    assign.Assign.Add(a);
                }
            }
        }

    }
}
