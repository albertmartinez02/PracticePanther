using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PP.Library.Models;
using PP.Library.Services;

namespace PP.MAUI.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Client Model { get; set; }

        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                //if this is a new client, we have no projects to return yet
                if (Model == null)
                {
                    return new ObservableCollection<ProjectViewModel>();
                }
                return new ObservableCollection<ProjectViewModel>(ProjectService
                    .Current.Projects.Where(p => p.ClientId == Model.Id)
                    .Select(r => new ProjectViewModel(r)));
            }
        }

        public ObservableCollection<BillViewModel> Bills
        {
            get
            {
                if(Model == null)
                {
                    return new ObservableCollection<BillViewModel>();
                }
                return new ObservableCollection<BillViewModel>(BillService
                    .Current.Bills.Where(b => b.ClientID == Model.Id)
                    .Select(r => new BillViewModel(r)));
            }
        }

        public ClientViewModel(Client c)
        {
            Model = c;
            SetUpCommands();
        }

        public ClientViewModel(int cid)
        {
            if (cid > 0)
            {
                Model = ClientService.Current.GetClient(cid);
            }
            else
            {
                Model = new Client();
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

        public string DisplayFullClient
        {
            get
            {
                string DFC = $" Name: {Model.Name}\n Is Active: {Model.IsActive}\n Client Notes: {Model.Notes}";
                return DFC;
            }
        }


        public void AddOrUpdate()
        {
            ClientService.Current.AddOrUpdate(Model);
            RefreshClientList();
        }

        public void AddProject()
        {
            AddOrUpdate();
            Shell.Current.GoToAsync($"//ProjectAddView?cid={Model.Id}");
        }


        public ICommand ViewCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public ICommand EditCommand { get; private set; }

        private void SetUpCommands()
        {
            ViewCommand = new Command(
                (c) => ExecuteViewCommand((c as ClientViewModel).Model.Id));
            DeleteCommand = new Command(
                (c) => ExecuteDeleteCommand((c as ClientViewModel).Model.Id));
            EditCommand = new Command(
                (c) => ExecuteEditCommand((c as ClientViewModel).Model.Id));
        }

        public void ExecuteViewCommand(int id)
        {
            Shell.Current.GoToAsync($"//ClientInfoView?clientViewId={id}");
        }

        public void ExecuteDeleteCommand(int id)
        {
            ClientService.Current.Delete(id);
            RefreshClientList();
        }

        public void ExecuteEditCommand(int id)
        {
            Shell.Current.GoToAsync($"//ClientAddView?clientId={id}");
        }

        public void RefreshClientList()
        {
            NotifyPropertyChanged(nameof(Client));
        }

        public void RefreshProjects()
        {
            NotifyPropertyChanged(nameof(Projects));
        }
    }
}
