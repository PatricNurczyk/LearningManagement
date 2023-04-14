using NetStandard.LearningMangement.Models;
using NetStandard.LearningMangement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.LearningManagement.Dialogs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPerson : Page
    {
        public string selectedType;
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }
        private string classification;
        public string Class
        {
            get { return classification; }
            set { classification = value; NotifyPropertyChanged("Class"); }
        }

        public PersonService personService;
        public AddPerson()
        {
            Name = "n";
            Class = "c";
            personService = PersonService.Current;
            DataContext = this;
            this.InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            switch (selectedType)
            {
                case "Student":
                    Students s = new Students();
                    s.Name = Name;
                    s.Classification = Class;
                    personService.Roster.Add(s);
                    break;
                case "Teacher":
                    Teacher t = new Teacher();
                    t.Name = Name;
                    t.Classification = Class;
                    personService.Roster.Add(t);
                    break;
                case "TA":
                    TA ta = new TA();
                    ta.Name = Name;
                    ta.Classification = Class;
                    personService.Roster.Add(ta);
                    break;
            }
            this.Frame.Navigate(typeof(MainPage));
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedType = e.AddedItems[0].ToString();
        }
    }
}
