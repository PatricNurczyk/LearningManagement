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
    public sealed partial class ViewContent : ContentDialog
    {
        public ContentItem DisplayContent { get; set; }

        public String HTMLBody { get; set; }
        public String FileItem { get; set; }
        public Assignment Assign { get; set; }
        public ViewContent(FileItem c)
        {
            DataContext = this;
            this.DisplayContent = c;
            this.FileItem = c.FilePath;
            this.HTMLBody = string.Empty;
            this.InitializeComponent();  
        }

        public ViewContent(PageItem p)
        {
            DataContext = this;
            this.DisplayContent = p;
            this.HTMLBody = p.HTMLBody;
            this.FileItem = string.Empty;
            this.InitializeComponent();
        }

        public ViewContent(AssignmentItem a)
        {
            DataContext = this;
            this.DisplayContent = a;
            this.Assign = a.assignmentItem;
            this.HTMLBody = string.Empty;
            this.FileItem = string.Empty;
            this.InitializeComponent();
        }

        public ViewContent(ContentItem c)
        {
            DataContext = this;
            this.DisplayContent = c;
            this.FileItem = string.Empty;
            this.HTMLBody= string.Empty;
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
