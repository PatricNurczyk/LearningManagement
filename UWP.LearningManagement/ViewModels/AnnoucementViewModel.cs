using NetStandard.LearningMangement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UWP.LearningManagement.ViewModels
{
    public class AnnoucementViewModel : INotifyPropertyChanged
    {
        private Annoucement display;
        public Annoucement Display
        {
            get { return display; }

            set 
            {
                display = value;
                NotifyPropertyChanged("Display");
            }
        }
        public AnnoucementViewModel(Annoucement a)
        {
            Display = a;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
