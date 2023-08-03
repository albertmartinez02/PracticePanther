using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PP.MAUI.ViewModels
{
    public class BillViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Bill Model { get; set; }

        public Time time { get; set; }

        public Employee employee { get; set; }

        public BillViewModel(int tid) //From TimeView
        {
            //Get Time object , with hours and employee id
            time = TimeService.Current.Get(tid); 
            employee = EmployeeService.Current.Get(time.EmployeeId);
            Model = new Bill();
            Model.TotalAmount = time.Hours * employee.Rate;
            Model.EmployeeID = employee.ID;
            Model.ProjectID = time.ProjectId;
            Model.ClientID = ProjectService.Current.Get(time.ProjectId).ClientId; //Get client's id
            //Initialize String Properties for binding
            totalhrs = time.Hours.ToString();
            employeerate = employee.Rate.ToString();
            total = Model.TotalAmount.ToString("N2");

            SetUpCommands();
        }

        public BillViewModel(Bill bill)
        {
            Model = bill;
            total = Model.TotalAmount.ToString("N2");
            employee = EmployeeService.Current.Get(Model.EmployeeID);
            employeerate = employee.Rate.ToString();
            ProjectName = ProjectService.Current.Get(Model.ProjectID).ShortName;
        }

        public string totalhrs { get; set; }

        public string employeerate { get; set; }

        public string total { get; set; }

        public string ProjectName { get; set; }

        public ICommand AddCommand { get; private set; }

        public void ExecuteAdd()
        {
            BillService.Current.Add(Model);
            time.BillGenerated = false;
            RefreshProperties();
        }
        
        public void SetUpCommands()
        {
            AddCommand = new Command(ExecuteAdd);
        }

        public void RefreshProperties()
        {
            NotifyPropertyChanged(nameof(Model));
            NotifyPropertyChanged(nameof(employee));
            NotifyPropertyChanged(nameof(time));
        }

        public string DisplayFullBill
        {
            get 
            {
                string DFB = $"Project: {ProjectName}\nTotal: {total}\nEmployee Name: {employee.Name}\nEmployee Rate: {employeerate}\nDue Date: {Model.DueDate.ToString()}";
                return DFB;
            }
        }
    }
}
