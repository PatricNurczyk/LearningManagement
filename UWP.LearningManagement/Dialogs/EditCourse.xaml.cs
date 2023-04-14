using NetStandard.LearningMangement.Models;
using NetStandard.LearningMangement.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP.LearningManagement.ViewModels;
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
    public sealed partial class EditCourse : Page
    {
        private CourseService c;
        public EditCourse()
        {
            this.InitializeComponent();
            DataContext = new CourseViewModel();
            c = CourseService.Current;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            foreach(Course c in c.Courses)
            {
                if (e.Parameter as string == c.Code)
                    (DataContext as CourseViewModel).CourseDisplay = c;
            }
            
        }

        private async void Annoucement_Click(object sender, RoutedEventArgs e)
        {
            var diag = new EditAnnoucement((DataContext as CourseViewModel).SelectedAnnoucement);
            await diag.ShowAsync();
            (DataContext as CourseViewModel).RefreshView();
        }

        private async void AddAnnoucement_Click(object sender, RoutedEventArgs e)
        {
            Annoucement newAnnoucement = new Annoucement();
            var diag = new EditAnnoucement(newAnnoucement);
            await diag.ShowAsync();
            (DataContext as CourseViewModel).CourseDisplay.Annoucements.Add(newAnnoucement);
            (DataContext as CourseViewModel).RefreshView();
        }

        private void RemoveAnnoucement_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as CourseViewModel).CourseDisplay.Annoucements.Remove((DataContext as CourseViewModel).SelectedAnnoucement);
            (DataContext as CourseViewModel).RefreshView();
        }
        private async void Module_Click(object sender, RoutedEventArgs e)
        {
            var diag = new Edit_Module((DataContext as CourseViewModel).SelectedModule);
            await diag.ShowAsync();
            (DataContext as CourseViewModel).RefreshView();
        }
        private async void AddModule_Click(object sender, RoutedEventArgs e)
        {
            var diag = new Edit_Module((DataContext as CourseViewModel).CourseDisplay);
            await diag.ShowAsync();
            (DataContext as CourseViewModel).RefreshView();
        }
        private void RemoveModule_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as CourseViewModel).CourseDisplay.Modules.Remove((DataContext as CourseViewModel).SelectedModule);
            (DataContext as CourseViewModel).RefreshView();
        }
        private void removePerson_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as CourseViewModel).CourseDisplay.Roster.Remove((DataContext as CourseViewModel).SelectedPerson as Students);
        }

        private async void basicInfo_Click(object sender, RoutedEventArgs e)
        {
            var select = new EditBasicInfo((DataContext as CourseViewModel).CourseDisplay);
            await select.ShowAsync();
            (DataContext as CourseViewModel).RefreshView();
        }

        private async void addAssign_Click(object sender, RoutedEventArgs e)
        {
            var diag = new AddAssign((DataContext as CourseViewModel).CourseDisplay);
            await diag.ShowAsync();
            (DataContext as CourseViewModel).RefreshView();
        }

        private async void editAssign_Click(object sender, RoutedEventArgs e)
        {
            var diag = new AddAssign((DataContext as CourseViewModel).SelectedAssignment);
            await diag.ShowAsync();
            (DataContext as CourseViewModel).RefreshView();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                for(int i = 0; i < c.Courses.Count(); ++i)
                {
                    if ((DataContext as CourseViewModel).CourseDisplay.Code == c.Courses[i].Code)
                    {
                        c.Courses[i] = (DataContext as CourseViewModel).CourseDisplay;
                        Frame.GoBack();
                    }
                }
               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as CourseViewModel).CourseDisplay.Assignments.Remove((DataContext as CourseViewModel).SelectedAssignment);
            (DataContext as CourseViewModel).RefreshView();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<string> args = new List<string>();
            args.Add((DataContext as CourseViewModel).CourseDisplay.Code);
            args.Add((DataContext as CourseViewModel).SelectedModule.Name);
            this.Frame.Navigate(typeof(EditContent), args.ToArray());
        }

        private void Manage_Click(object sender, RoutedEventArgs e)
        {
            List<string> args = new List<string>();
            args.Add((DataContext as CourseViewModel).CourseDisplay.Code);
            args.Add((DataContext as CourseViewModel).SelectedAssignment.Name);
            this.Frame.Navigate(typeof(ManageGrades), args.ToArray());
        }
    }
}
