using PP.Library.Models;
using PP.Library.Services;
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
    public class EmployeeViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand SearchCommand { get; private set; }
        public ICommand AddCommand { get; private set; }

        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Employees));
        }

        public void ExecuteAddCommand()
        {
            Shell.Current.GoToAsync("//EmployeeAddView?employeeId=0");
        }

        public EmployeeViewViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand);
            AddCommand = new Command(ExecuteAddCommand);
        }
        public string Query { get; set; }

        public ObservableCollection<EmployeeViewModel> Employees
        {
            get
            {
                return
                    new ObservableCollection<EmployeeViewModel>
                    (EmployeeService
                        .Current.Search(Query ?? string.Empty)
                        .Select(c => new EmployeeViewModel(c)).ToList());
            }
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Employees));
        }
    }
}
