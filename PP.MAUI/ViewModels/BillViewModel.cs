using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PP.MAUI.ViewModels
{
    public class BillViewModel
    {
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
            //Initialize String Properties for binding
            totalhrs = time.Hours.ToString();
            employeerate = employee.Rate.ToString();
            total = Model.TotalAmount.ToString("N2");

            SetUpCommands();
        }

        public string totalhrs { get; set; }

        public string employeerate { get; set; }

        public string total { get; set; }

        public ICommand AddCommand { get; private set; }

        public void ExecuteAdd()
        {
            BillService.Current.Add(Model);
        }
        
        public void SetUpCommands()
        {
            AddCommand = new Command(ExecuteAdd);
        }
    }
}
