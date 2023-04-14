using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using UWP.LearningManagement.ViewModels;
using UWP.LearningManagement.Dialogs;
using Windows.Devices.Enumeration;
using Newtonsoft.Json;
using NetStandard.LearningMangement.Models;
using NetStandard.LearningManagement.Models;
using NetStandard.LearningMangement.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP.LearningManagement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new MainViewModel();
            if (MainViewModel.ID < 0)
            {
                LoadLogin();
            }
            else
            {
                (DataContext as MainViewModel).ClearView();
                (DataContext as MainViewModel).LoadMainView();
            }
        }

        private async void LoadLogin()
        {
            (DataContext as MainViewModel).ClearView();
            var diag = new Login();
            await diag.ShowAsync();
            (DataContext as MainViewModel).LoadMainView();
        }

        private async void loadEnroller()
        {
            var diag = new CourseEnroller();
            await diag.ShowAsync();
            (DataContext as MainViewModel).ClearView();
            (DataContext as MainViewModel).LoadMainView();
        }

        private void Relog_Click(object sender, RoutedEventArgs e)
        {
            LoadLogin();
        }

        private void courseView_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DisplayCourse), (DataContext as MainViewModel).SelectedCourse.Code);
        }

        private void courseEdit_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EditCourse), (DataContext as MainViewModel).SelectedCourse.Code);
        }

        private void personAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddPerson));
        }

        private void personRemove_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).personService.Roster.Remove((DataContext as MainViewModel).SelectedPerson);
            (DataContext as MainViewModel).ClearView();
            (DataContext as MainViewModel).LoadMainView();
        }

        private async void personEdit_Click(object sender, RoutedEventArgs e)
        {
            var diag = new EditPerson((DataContext as MainViewModel).SelectedPerson);
            await diag.ShowAsync();
            (DataContext as MainViewModel).ClearView();
            (DataContext as MainViewModel).LoadMainView();
        }

        private void Enroll_Click(object sender, RoutedEventArgs e)
        {
            loadEnroller();
        }

        private void Drop_Click(object sender, RoutedEventArgs e)
        {
            foreach (Person p in (DataContext as MainViewModel).personService.Roster)
            {
                if (MainViewModel.ID == p.ID)
                {
                    foreach(Course c in (p as Students).CourseTaking)
                    {
                        if (c.Code == (DataContext as MainViewModel).SelectedCourse.Code)
                        {
                            p.CourseTaking.Remove(c);
                            break;
                        }
                    }
                }
            }
            (DataContext as MainViewModel).ClearView();
            (DataContext as MainViewModel).LoadMainView();
        }

        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddCourse));
        }

        private void RemoveCourse_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).courseService.Courses.Remove((DataContext as MainViewModel).SelectedCourse);
            (DataContext as MainViewModel).ClearView();
            (DataContext as MainViewModel).LoadMainView();

        }

        public void TimeForward_Click(object sender, RoutedEventArgs e)
        {
            int month = (DataContext as MainViewModel).Date.Month;
            int year = (DataContext as MainViewModel).Date.Year;
            if (month == 12)
            {
                ++year;
                month = 1;
            }
            else
            {
                ++month;
            }
            switch (month)
            {
                case 1:
                    foreach (Person p in PersonService.Current.Roster)
                    {
                        for (int i = 0; i < p.CourseTaking.Count; i++)
                        {
                            if (p.CourseTaking[i].Semester == "Spring")
                            {
                                p.PastCourse.Add(p.CourseTaking[i]);
                                p.CourseTaking.RemoveAt(i);
                            }
                        }
                    }
                    break;
                case 5:
                    foreach (Person p in PersonService.Current.Roster)
                    {
                        for (int i = 0; i < p.CourseTaking.Count; i++)
                        {
                            if (p.CourseTaking[i].Semester == "Spring")
                            {
                                p.PastCourse.Add(p.CourseTaking[i]);
                                p.CourseTaking.RemoveAt(i);
                            }
                        }
                    }
                    break;
                case 8:
                    foreach (Person p in PersonService.Current.Roster)
                    {
                        for (int i = 0; i < p.CourseTaking.Count; i++)
                        {
                            if (p.CourseTaking[i].Semester == "Spring")
                            {
                                p.PastCourse.Add(p.CourseTaking[i]);
                                p.CourseTaking.RemoveAt(i);
                            }
                        }
                    }
                    break;
            }
            (DataContext as MainViewModel).Date = new SemesterDate(month, year);
            (DataContext as MainViewModel).ClearView();
            (DataContext as MainViewModel).LoadMainView();
        }
        public void Past_Click(object sender, RoutedEventArgs e)
        {
            if ((DataContext as MainViewModel).past)
                (DataContext as MainViewModel).past = false;
            else
                (DataContext as MainViewModel).past = true;
            (DataContext as MainViewModel).ClearView();
            (DataContext as MainViewModel).LoadMainView();
        }

        public async void ViewPerson_Click(object sender, RoutedEventArgs e)
        {
            if ((DataContext as MainViewModel).SelectedPerson.GetType() == typeof(Students))
            {
                var diag = new ShowPerson((DataContext as MainViewModel).SelectedPerson as Students);
                await diag.ShowAsync();
            }
            else
            {
                var diag = new ShowPerson((DataContext as MainViewModel).SelectedPerson);
                await diag.ShowAsync();
            }
               
        }

        public void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel).SelectedPerson.CourseTaking.Add((DataContext as MainViewModel).SelectedCourse);
            (DataContext as MainViewModel).SelectedCourse.Roster.Add((DataContext as MainViewModel).SelectedPerson);
        }
    }

    
}
