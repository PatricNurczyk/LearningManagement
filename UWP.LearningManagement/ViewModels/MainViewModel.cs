using NetStandard.LearningMangement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.LearningManagement.Dialogs;
using NetStandard.LearningMangement.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;

namespace UWP.LearningManagement.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public static int ID = -1;
        public CourseService courseService { get; set; }
        public PersonService personService { get; set; }

        private List<Person> displayPersons;
        public List<Person> DisplayPersons
        {
            get
            {
                return displayPersons;
            }
            set
            {
                displayPersons = value;

                NotifyPropertyChanged("DisplayPersons");
            }
        }
        private List<Course> displayCourses;
        public List<Course> DisplayCourses
        {
            get
            {
                return displayCourses;
            }
            set
            {
                displayCourses = value;

                NotifyPropertyChanged("DisplayCourses");
            }
        }
        public Course SelectedCourse { get; set; }
        public Person SelectedPerson { get; set; }

        private Visibility admin;
        public Visibility Admin
        {
            get
            {
                return admin;
            }
            set
            {
                admin = value;

                NotifyPropertyChanged("Admin");
            }
        }

        private Visibility student;
        public Visibility Student
        {
            get
            {
                return student;
            }
            set
            {
                student = value;

                NotifyPropertyChanged("Student");
            }
        }
        public MainViewModel() 
        {
            courseService = CourseService.Current;
            personService = PersonService.Current;
            DisplayCourses = new List<Course>();
            DisplayPersons= new List<Person>();
        }

        public void LoadMainView()
        {
            if (ID == 0)
            {
                DisplayCourses = courseService.Courses;
                DisplayPersons = personService.Roster;
                Admin = Visibility.Visible;
            }
            else
            {
                foreach(Person person in personService.Roster)
                {
                    if (ID == person.ID)
                    {
                        if (person.GetType() == typeof(Students))
                        {
                            DisplayCourses = (person as Students).CourseTaken;
                            Student = Visibility.Visible;
                        }
                        else if (person.GetType() == typeof(Teacher) || person.GetType() == typeof(TA))
                        {
                            DisplayCourses = courseService.Courses;
                            DisplayPersons = personService.Roster;
                            Admin = Visibility.Visible;
                        }
                    }
                }
            }
        }

        public void ClearView()
        {
            Admin = Visibility.Collapsed;
            Student = Visibility.Collapsed;
            DisplayCourses = new List<Course>();
            DisplayPersons = new List<Person>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
