using NetStandard.LearningMangement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UWP.LearningManagement.ViewModels
{
    public class CourseViewModel : INotifyPropertyChanged
    {
        private Course courseDisplay;

        private Course holder;

        public Annoucement SelectedAnnoucement { get; set; }
        public Person SelectedPerson { get; set; }
        public Module SelectedModule { get; set; }
        public AssignmentGroup SelectedAssignment { get; set; }

        private List<Annoucement> annList;

        public string Location { get; set; }

        public List<Annoucement> AnnoucementList
        {
            get
            {
                return annList;
            }
            set
            {
                annList =  value;
                NotifyPropertyChanged("AnnoucementList");
            }
        }

        public Course CourseDisplay
        {
            get
            {
                return courseDisplay;
            }
            set
            {
                courseDisplay = value;
                AnnoucementList = courseDisplay.Annoucements;
                Location = $"{courseDisplay.Semester} Room: {courseDisplay.Room}";
                NotifyPropertyChanged("CourseDisplay");
            }
        }
        public void RefreshView()
        {
            AnnoucementList = new List<Annoucement>();
            AnnoucementList = courseDisplay.Annoucements;
            holder = CourseDisplay;
            CourseDisplay = new Course();
            CourseDisplay= holder;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
