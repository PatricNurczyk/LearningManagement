using Library.Project_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Project_2.Services
{
    public class CourseService
    {
        private static CourseService instance;

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
        }

        public void AddCourse(Course c)
        {
            Courses.Add(c);
        }

    }
}
