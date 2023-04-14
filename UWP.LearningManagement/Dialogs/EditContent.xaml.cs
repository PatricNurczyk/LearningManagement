using NetStandard.LearningMangement.Models;
using NetStandard.LearningMangement.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public sealed partial class EditContent : Page
    {
        public Module DisplayModule { get; set; }
        private CourseService c;
        private Course course;
        public ContentItem SelectedContent { get; set; }
        private List<ContentItem> items;
        public List<ContentItem> Items
        {
            get { return items; }
            set { items = value; NotifyPropertyChanged("Items"); }
        }
        public EditContent()
        {
            DataContext = this;
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string[] args = (string[])e.Parameter;
            c = CourseService.Current;
            foreach (Course c in c.Courses)
            {
                if (args[0] == c.Code)
                {
                    course = c;
                    foreach (Module m in c.Modules)
                    {
                        if (args[1] == m.Name)
                        {
                            DisplayModule = m;
                        }
                    }
                }
            }
            Items = DisplayModule.ContentItems;
        }

        private async void SelectContent_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < DisplayModule.ContentItems.Count; ++i)
            {
                if (DisplayModule.ContentItems[i].Name == SelectedContent.Name)
                {
                    if (DisplayModule.ContentItems[i].GetType() == typeof(PageItem))
                    {
                        var diag = new AddContent(DisplayModule.ContentItems[i] as PageItem, DisplayModule);
                        await diag.ShowAsync();
                    }
                    else if (DisplayModule.ContentItems[i].GetType() == typeof(FileItem))
                    {
                        var diag = new AddContent(DisplayModule.ContentItems[i] as FileItem, DisplayModule);
                        await diag.ShowAsync();
                    }
                    else if (DisplayModule.ContentItems[i].GetType() == typeof(AssignmentItem))
                    {
                        var diag = new AddContent(DisplayModule.ContentItems[i] as AssignmentItem, DisplayModule, course);
                        await diag.ShowAsync();
                    }
                }
            }
            Refresh();
        }
        private async void AddAssignment_Click(object sender, RoutedEventArgs e)
        {
            AssignmentItem assign = new AssignmentItem();
            var diag = new AddContent(assign, DisplayModule, course);
            await diag.ShowAsync();
            DisplayModule.ContentItems.Add(assign);
            Refresh();
        }
        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            PageItem page = new PageItem();
            var diag = new AddContent(page, DisplayModule);
            await diag.ShowAsync();
            DisplayModule.ContentItems.Add(page);
            Refresh();
        }
        private async void AddFile_Click(object sender, RoutedEventArgs e)
        {
            FileItem file = new FileItem();
            var diag = new AddContent(file, DisplayModule);
            await diag.ShowAsync();
            DisplayModule.ContentItems.Add(file);
            Refresh();
        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void Refresh()
        {
            Items = new List<ContentItem>();
            Items = DisplayModule.ContentItems;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
