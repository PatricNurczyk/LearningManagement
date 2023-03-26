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
            Courses = new List<Course>();
            Course c = new Course();
            c.Name = "TestCourse";
            c.Code = "COP1234";
            Courses.Add(c);
        }

        public void AddCourse(Course c)
        {
            Courses.Add(c);
        }

    }
}
