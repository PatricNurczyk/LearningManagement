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
using UWP.LearningManagement.ViewModels;
using UWP.LearningManagement.Dialogs;
using Windows.Devices.Enumeration;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP.LearningManagement
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new MainViewModel();
            LoadLogin();
        }

        private async void LoadLogin()
        {
            (DataContext as MainViewModel).ClearView();
            var diag = new Login();
            await diag.ShowAsync();
            (DataContext as MainViewModel).LoadMainView();
        }

        private void Relog_Click(object sender, RoutedEventArgs e)
        {
            LoadLogin();
        }
    }
}
