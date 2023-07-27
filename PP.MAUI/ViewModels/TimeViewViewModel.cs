using PP.Library.Services;
using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PP.MAUI.ViewModels
{
    public class TimeViewViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<TimeViewModel> Times
        {
            get
            {
                return new ObservableCollection<TimeViewModel>
                    (TimeService.Current.Times.Select(t => new TimeViewModel(t)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshTimes()
        {
            NotifyPropertyChanged("Times");
        }
    }
}
