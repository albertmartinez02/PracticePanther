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
    public class ProjectViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Project Model { get; set; }

        public ICommand AddCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public ICommand EditCommand { get; private set; }

        public ICommand TimerCommand { get; private set; }
        private void ExecuteAdd()
        {
            ProjectService.Current.AddProject(Model);
            Shell.Current.GoToAsync($"//ClientAddView?clientId={Model.ClientId}");
        }

        private void ExecuteDelete()
        {
            ProjectService.Current.Delete(Model);
            NotifyPropertyChanged(nameof(Project));
        }

        private void ExecuteEdit()
        {
            Shell.Current.GoToAsync($"//ProjectAddView?pid={Model.ID}");
        }

        public void SetUpCommands()
        {
            AddCommand = new Command(ExecuteAdd);
            DeleteCommand = new Command(ExecuteDelete);
            EditCommand = new Command(ExecuteEdit);
        }

        public string Display
        {
            get
            {
                return Model.ToString();
            }
        }

        public string DisplayFullProject
        {
            get
            {
                string DFP = $"ShortName: {Model.ShortName}\nLongName: {Model.LongName}\nIsActive: {Model.IsActive}\n";
                return DFP;
            }
        }

        public ProjectViewModel()
        {
            Model = new Project();
        }

        public ProjectViewModel(int clientId)
        {
            Model = new Project { ClientId = clientId };
            SetUpCommands();
        }

        public ProjectViewModel(int projectId, bool edit)
        {
            edit = true; //Constructor for ProjectViewModel in edit situation , edit bool does nothing
            Model = ProjectService.Current.Get(projectId);
            SetUpCommands();
        }

        public ProjectViewModel(Project model)
        {
            Model = model;
            SetUpCommands();
        }

        public void Add()
        {
            ProjectService.Current.AddProject(Model);
        }
    }
}
