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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.LearningManagement.Dialogs
{
    public sealed partial class AddContent : ContentDialog
    {
        private CourseService c { get; set; }
        private Course course { get; set; }
        public AssignmentItem itemA { get; set; }
        public PageItem itemP { get; set; }
        public FileItem itemF { get; set; }
        public string type { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }
        public string HTMLBody { get; set; }
        public string Path { get; set; }
        public Assignment assignment { get; set; }

        public Module DisplayModule { get; set; }
        public List<AssignmentGroup> AssignmentGroups { get; set; }

        public string selectedAssignment { get; set; }

        private Visibility assign;

        public Visibility Assign
        {
            get { return assign; }
            set { assign = value; NotifyPropertyChanged("Assign"); }
        }
        private Visibility page;

        public Visibility Page
        {
            get { return page; }
            set { page = value; NotifyPropertyChanged("Page"); }
        }
        private Visibility file;

        public Visibility File
        {
            get { return file; }
            set { file = value; NotifyPropertyChanged("File"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public AddContent(AssignmentItem a, Module m, Course c)
        {
            itemA = a;
            course = c;
            DataContext = this;
            DisplayModule = m;
            Name = a.Name;
            Description = a.Description;
            assignment = a.assignmentItem;
            AssignmentGroups = c.Assignments;
            this.InitializeComponent();
            Assign = Visibility.Visible;
            File = Visibility.Collapsed;
            Page = Visibility.Collapsed;
            this.c = CourseService.Current;
            type = "assign";
        }

        public AddContent(PageItem p, Module c)
        {
            itemP = p;
            DataContext = this;
            DisplayModule = c;
            Name = p.Name;
            Description = p.Description;
            HTMLBody = p.HTMLBody;
            this.InitializeComponent();
            Assign = Visibility.Collapsed;
            File = Visibility.Collapsed;
            Page = Visibility.Visible;
            this.c = CourseService.Current;
            type = "page";
        }

        public AddContent(FileItem f, Module c)
        {
            itemF = f;
            DataContext = this;
            DisplayModule = c;
            Name = f.Name;
            Description = f.Description;
            Path = f.FilePath;
            this.InitializeComponent();
            Assign = Visibility.Collapsed;
            File = Visibility.Visible;
            Page = Visibility.Collapsed;
            this.c = CourseService.Current;
            type = "file";
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            switch (type)
            {
                case "assign":
                    itemA.Name = Name;
                    itemA.Description = Description;
                    itemA.assignmentItem = assignment;
                    for (int i = 0; i < AssignmentGroups.Count; ++i)
                    {
                        if (AssignmentGroups[i].Name == selectedAssignment)
                        {
                            c.AddAssignment(course, assignment, selectedAssignment);
                        }
                    }
                    break;
                case "page":
                    itemP.Name = Name;
                    itemP.Description = Description;
                    itemP.HTMLBody = HTMLBody;
                    break;
                case "file":
                    itemF.Name = Name;
                    itemF.Description = Description;
                    itemF.FilePath = Path;
                    break;
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }


    }
}
