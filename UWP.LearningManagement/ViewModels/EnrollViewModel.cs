using NetStandard.LearningMangement.Models;
using NetStandard.LearningMangement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UWP.LearningManagement.ViewModels
{
    public class EnrollViewModel : INotifyPropertyChanged
    {
        private CourseService courseService;
        private List<Course> enrollments;
        public Course SelectedCourse { get; set; }
        public List<Course> Enrollments
        {
            get { return enrollments;}
            set 
            { 
                enrollments = value; 
                NotifyPropertyChanged("Enrollments"); 
            }
        }
        public EnrollViewModel() 
        {
            courseService = CourseService.Current;
            Enrollments = courseService.Courses;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
