using NetStandard.LearningMangement.Models;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.LearningManagement.Dialogs
{
    public sealed partial class EditAnnoucement : ContentDialog
    {
        private Course c;
        private string head;
        private string body;
        public EditAnnoucement(Annoucement a)
        {
            this.InitializeComponent();
            DataContext = new AnnoucementViewModel(a);
            head = (DataContext as AnnoucementViewModel).Display.Heading;
            body = (DataContext as AnnoucementViewModel).Display.Content;
        }

        public EditAnnoucement(Course c)
        {
            DataContext = new AnnoucementViewModel(new Annoucement());
            this.c = c;
        }
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (c != null)
            {
                c.Annoucements.Add((DataContext as AnnoucementViewModel).Display);
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            (DataContext as AnnoucementViewModel).Display.Heading = head;
            (DataContext as AnnoucementViewModel).Display.Content = body;
        }
    }
}
