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
    public class TimeViewModel : INotifyPropertyChanged
    {

        public Time Model { get; set; }

        public string HourDisplay
        {
            get
            {
                return Model.Hours.ToString();
            }
            set
            {
                if (Decimal.TryParse(value, out decimal v))
                {
                    Model.Hours = v;
                }
            }
        }

        private Employee employee;

        public Employee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                if (employee != null)
                {
                    Model.EmployeeId = employee.ID;
                }
            }
        }

        public string EmployeeDisplay => Employee?.Name ?? string.Empty;

        private Project project;

        public Project Project
        {
            get
            {
                return project;
            }
            set
            {
                project = value;
                if (project != null)
                {
                    Model.ProjectId = project.ID;
                }
            }
        }


        public string ProjectDisplay => Project?.ShortName ?? string.Empty;

        public ICommand DeleteCommand { get; private set; }

        public ICommand EditCommand { get; private set; }

        public ICommand GenerateBillCommand { get; private set; }

        public void ExecuteDelete()
        {
            TimeService.Current.Delete(Model);
            NotifyPropertyChanged(nameof(Time));
        }

        public void ExecuteEdit()
        {
            Shell.Current.GoToAsync($"//TimeEdit?timeID={Model.Id}");
        }

        public void ExecuteGenerate()
        {
            Shell.Current.GoToAsync($"//BillAddView?timeID={Model.Id}");
            NotifyPropertyChanged(nameof(Time));
            NotifyPropertyChanged(nameof(TimeViewModel));
        }

        public void SetUpCommands()
        {
            DeleteCommand = new Command(ExecuteDelete);
            EditCommand = new Command(ExecuteEdit);
            GenerateBillCommand = new Command(ExecuteGenerate);
        }

        public ObservableCollection<Employee> Employees
            => new ObservableCollection<Employee>(EmployeeService.Current.Employees);

        public ObservableCollection<Project> Projects
            => new ObservableCollection<Project>(ProjectService.Current.Projects);


        public TimeViewModel()
        {
            Model = new Time();
            SetUpCommands();
        }

        public TimeViewModel(Time t)
        {
            Model = t;
            var employee = EmployeeService.Current.Get(t.EmployeeId);
            if (employee != null)
            {
                Employee = employee;
            }
            var project = ProjectService.Current.Get(t.ProjectId);
            if (project != null)
            {
                Project = project;
            }
            SetUpCommands();
        }

        public TimeViewModel(int tid)
        {
            if (tid > 0)
            {
                Model = TimeService.Current.Get(tid);
                var employee = EmployeeService.Current.Get(Model.EmployeeId);
                if (employee != null)
                {
                    Employee = employee;
                }
                SetUpCommands();
            }
        }

        public void AddOrUpdate()
        {
            TimeService.Current.AddOrUpdate(Model);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
