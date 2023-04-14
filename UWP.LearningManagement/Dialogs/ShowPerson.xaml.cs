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
    public sealed partial class ShowPerson : ContentDialog
    {
        public string Name { get; set; }
        public string Classification { get; set; }

        public string gpa { get; set; }
        public ShowPerson(Person p)
        {
            DataContext = this;
            Name = p.Name;
            Classification = p.Classification;
            gpa = string.Empty;
            this.InitializeComponent();
        }

        public ShowPerson(Students p)
        {
            DataContext = this;
            Name = p.Name;
            Classification = p.Classification;
            gpa = $"GPA: {p.GPA}";
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
