using NetStandard.LearningMangement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
using Windows.Storage;
using NetStandard.LearningMangement.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.LearningManagement.Dialogs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DisplayCourse : Page
    {
        private CourseService c { get; set; }
        public DisplayCourse()
        {
            c = CourseService.Current;
            DataContext = new CourseViewModel();
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            foreach (Course c in c.Courses)
            {
                if (e.Parameter as string == c.Code)
                    (DataContext as CourseViewModel).CourseDisplay = c;
            }
        }

        private async void Annoucement_Click(object sender, RoutedEventArgs e)
        {
            var diag = new ShowAnnoucement((DataContext as CourseViewModel).SelectedAnnoucement);
            await diag.ShowAsync();
        }

        private async void Module_Click(object sender, RoutedEventArgs e)
        {
            var currMod = JsonConvert.SerializeObject((DataContext as CourseViewModel).SelectedModule);
            this.Frame.Navigate(typeof(ViewModule), currMod); 
        }

        private void viewPerson_Click(object sender, RoutedEventArgs e)
        {

        }
        private void viewAssign_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }
    }
}
