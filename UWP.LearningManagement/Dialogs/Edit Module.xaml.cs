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
    public sealed partial class Edit_Module : ContentDialog
    {
        private Module newMod { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public Edit_Module()
        {
            DataContext = this;
            newMod = new Module();
            this.InitializeComponent();
        }

        public Edit_Module(Course courseDisplay)
        {
            CourseDisplay = courseDisplay;
            newMod= new Module();
            DataContext = this;
            this.InitializeComponent();
        }

        public Edit_Module(Module m)
        {
            DataContext = this;
            newMod = m;
            Name = m.Name;
            Description = m.Description;
            this.InitializeComponent();
        }

        public Course CourseDisplay { get; }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            newMod.Name = Name;
            newMod.Description = Description;
            if (CourseDisplay != null)
                CourseDisplay.Modules.Add(newMod);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
