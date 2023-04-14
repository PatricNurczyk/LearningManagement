using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NetStandard.LearningMangement.Models;

namespace NetStandard.LearningMangement.Services
{
    public class PersonService
    {
        public List<Person> Roster { get; set; }

        protected static PersonService instance;

        public static PersonService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new PersonService();
                }
                return instance;
            }
        }

        private PersonService()
        {
            Roster = new List<Person>();
            Students s = new Students();
            s.Name = "Billy Tester";
            s.Classification = "Freshmen";
            Roster.Add(s);
            Teacher t = new Teacher();
            t.Name = "Teacher Tester";
            t.Classification = "Professor";
            Roster.Add(t);

        }

        public char PersonType(int ID)
        {
            if (ID == 0)
            {
                //Admin
                return 'a';
            }
            else
            foreach(Person person in Roster)
            {
                if (person.ID == ID)
                {
                    if(person.GetType() == typeof(Teacher) || person.GetType() == typeof(TA))
                    {
                        return 't';
                    }
                    else if(person.GetType() == typeof(Students))
                    {
                        return 's';
                    }

                }
            }
            return 's';
        }

        public void EnrollCourse(Students person, Course selectedCourse)
        {
            selectedCourse.Roster.Add(person);
            person.CourseTaking.Add(selectedCourse);
            person.Grades.Add(selectedCourse.Code, new Grades(selectedCourse));
        }

        public void DropCourse(Students person, Course selectedCourse)
        {
            selectedCourse.Roster.Remove(person);
            person.CourseTaking.Remove(selectedCourse);
            person.Grades.Remove(selectedCourse.Code);
            UpdateGPA(person);
        }

        public void UpdateGPA(Students selectedStudent)
        {
            float gradePoints = 0;
            float hours = 0;
            foreach (Grades g in selectedStudent.Grades.Values.ToArray())
            {
                hours += g.creditHours;
                if (g.Grade >= 92)
                {
                    gradePoints += 4f * g.creditHours;
                }
                else if (g.Grade >= 88)
                {
                    gradePoints += 3.75f * g.creditHours;
                }
                else if (g.Grade >= 85)
                {
                    gradePoints += 3.25f * g.creditHours;
                }
                else if (g.Grade >= 81)
                {
                    gradePoints += 3f * g.creditHours;
                }
                else if (g.Grade >= 78)
                {
                    gradePoints += 2.75f * g.creditHours;
                }
                else if (g.Grade >= 75)
                {
                    gradePoints += 2.25f * g.creditHours;
                }
                else if (g.Grade >= 72)
                {
                    gradePoints += 2f * g.creditHours;
                }
                else if (g.Grade >= 69)
                {
                    gradePoints += 1.75f * g.creditHours;
                }
                else if (g.Grade >= 65)
                {
                    gradePoints += 1.25f * g.creditHours;
                }
                else if (g.Grade >= 60)
                {
                    gradePoints += 1f * g.creditHours;
                }
            }
            selectedStudent.GPA = (gradePoints / hours);
        }
    }
}

