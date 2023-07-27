using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PP.Library.Models;
using PP.Library.Services;

namespace PP.MAUI.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public Employee Model { get; set; }

        public string ModelRate { get; set; }

        public void StringToDecimal(string d) //Initialize Employee Rate of Pay
        {
            Model.Rate = decimal.Parse(d, CultureInfo.InvariantCulture);
        }
        public void AddOrUpdate()
        {
            if (ModelRate != null)
            {
                StringToDecimal(ModelRate);
            }
            EmployeeService.Current.Add(Model);
            RefreshEmployeeList();
        }

        public EmployeeViewModel(Employee e)
        {
            Model = e;
            SetUpCommands();
        }

        public EmployeeViewModel(int eid)
        {
            if (eid > 0)
            {
                Model = EmployeeService.Current.Get(eid);
            }
            else
            {
                Model = new Employee();
            }
            SetUpCommands();
        }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public ICommand DeleteCommand { get; private set; }

        public ICommand EditCommand { get; private set; }

        public void ExecuteDelete(int eid)
        {
            EmployeeService.Current.Delete(eid);
            RefreshEmployeeList();
        }

        public void ExecuteEdit()
        {
            Shell.Current.GoToAsync($"//EmployeeAddView?employeeId={Model.ID}");
        }

        public void SetUpCommands()
        {
            DeleteCommand = new Command(
                (e) => ExecuteDelete((e as EmployeeViewModel).Model.ID));
            EditCommand = new Command(ExecuteEdit);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshEmployeeList()
        {
            NotifyPropertyChanged(nameof(Employee));
        }

    }
}
