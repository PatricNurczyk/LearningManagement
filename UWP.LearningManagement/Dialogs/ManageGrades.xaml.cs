using NetStandard.LearningMangement.Models;
using NetStandard.LearningMangement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.LearningManagement.Dialogs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ManageGrades : Page
    {

        public CourseService c { get; set; }
        public Course course { get; set; }

        public AssignmentGroup DisplayAssignment { get; set; }

        private List<Students> roster;
        public List<Students> Roster
        {
            get { return roster; }
            set { roster = value; NotifyPropertyChanged("Roster"); }
        }

        private List<Assignment> items;
        public List<Assignment> Items
        {
            get { return items; }
            set { items = value; NotifyPropertyChanged("Items"); }
        }

        public Students SelectedStudent { get; set; }
        public Assignment SelectedAssign { get; set; }
        public ManageGrades()
        {
            DataContext = this;

            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Roster = new List<Students>();
            Items = new List<Assignment>();
            string[] args = (string[])e.Parameter;
            c = CourseService.Current;
            foreach (Course c in c.Courses)
            {
                if (args[0] == c.Code)
                {
                    course = c;
                    foreach (AssignmentGroup assignment in c.Assignments)
                    {
                        if (args[1] == assignment.Name)
                        {
                            DisplayAssignment = assignment;
                            Items = DisplayAssignment.Assign;
                        }
                    }
                }
            }
            foreach (Person p in course.Roster)
            {
                if (p.GetType() == typeof(Students))
                {
                    Roster.Add(p as Students);
                    NotifyPropertyChanged("Roster");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void Remove_Click(object sender, RoutedEventArgs e)
        {
            Items.Remove(SelectedAssign);
            List<Assignment> temp = Items;
            Items = new List<Assignment>();
            Items = temp;
        }

        public async void Grade_Click(object sender, RoutedEventArgs e)
        {
            var diag = new Grade_Assignment(SelectedAssign, SelectedStudent,course.Code, DisplayAssignment.Name);
            await diag.ShowAsync();
        }

        public void Return_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
