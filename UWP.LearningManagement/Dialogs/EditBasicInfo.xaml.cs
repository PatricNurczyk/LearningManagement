using NetStandard.LearningMangement.Models;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.LearningManagement.Dialogs
{
    public sealed partial class EditBasicInfo : ContentDialog
    {
        public Course course { get; set; }
        public string Code { get; set; }
        public string cName { get; set; }

        public string Desc { get; set; }

        public int credits { get; set; }

        public string Semester { get; set; }

        public string room { get; set; }
        public EditBasicInfo(Course c)
        {
            this.course = c;
            Code = course.Code;
            cName = course.Name;
            Desc = course.Description;
            credits = course.creditHours;
            Semester = course.Semester;
            room = course.Room;
            DataContext = this;
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            course.Code = Code;
            course.Name = cName;
            course.Description = Desc;
            course.creditHours = credits;
            course.Semester = Semester;
            course.Room = room;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
