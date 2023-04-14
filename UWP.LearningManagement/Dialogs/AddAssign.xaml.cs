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
    public sealed partial class AddAssign : ContentDialog
    {
        private AssignmentGroup newAssign { get; set; }
        public string Name { get; set; }
        public float Percent { get; set; }

        public AddAssign()
        {
            DataContext = this;
            newAssign = new AssignmentGroup();
            this.InitializeComponent();
        }

        public AddAssign(Course courseDisplay)
        {
            CourseDisplay = courseDisplay;
            newAssign = new AssignmentGroup();
            DataContext = this;
            this.InitializeComponent();
        }

        public AddAssign(AssignmentGroup a)
        {
            DataContext = this;
            newAssign = a;
            Name = a.Name;
            Percent = a.Percentage;
            this.InitializeComponent();
        }

        public Course CourseDisplay { get; }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            newAssign.Name = Name;
            newAssign.Percentage= Percent;
            if (CourseDisplay != null)
                CourseDisplay.Assignments.Add(newAssign);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
