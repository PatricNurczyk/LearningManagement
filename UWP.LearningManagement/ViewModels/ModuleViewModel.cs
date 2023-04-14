using NetStandard.LearningMangement.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UWP.LearningManagement.ViewModels
{
    public class ModuleViewModel : INotifyPropertyChanged
    {
        private Module mod;
        public ContentItem SelectedItem { get; set; }
        public Module ModuleDisplay
        {
            get
            {
                return mod;
            }
            set
            {
                mod = value;

                NotifyPropertyChanged("ModuleDisplay");
            }
        }

        public ModuleViewModel(Module mod)
        {
            ModuleDisplay = mod;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
