using NetStandard.LearningMangement.Models;
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
    public sealed partial class ViewModule : Page
    {
        private Module m { get; set; }
        public ViewModule()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
                DataContext = new ModuleViewModel(JsonConvert.DeserializeObject<Module>((string)e.Parameter));
                
        }

        private async void SelectContent_Click(object sender, RoutedEventArgs e)
        {
            /* if ((DataContext as ModuleViewModel).SelectedItem.GetType() == typeof(FileItem))
             {
                  var diag = new ViewContent((DataContext as ModuleViewModel).SelectedItem as FileItem);
                  await diag.ShowAsync();
             }
             else if ((DataContext as ModuleViewModel).SelectedItem.GetType() == typeof(PageItem))
             {
                 var diag = new ViewContent((DataContext as ModuleViewModel).SelectedItem as PageItem);
                 await diag.ShowAsync();
             }
             else if ((DataContext as ModuleViewModel).SelectedItem.GetType() == typeof(AssignmentItem))
             {
                 var diag = new ViewContent((DataContext as ModuleViewModel).SelectedItem as AssignmentItem);
                 await diag.ShowAsync();
             }
            */
            var diag = new ViewContent((DataContext as ModuleViewModel).SelectedItem);
            await diag.ShowAsync();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
