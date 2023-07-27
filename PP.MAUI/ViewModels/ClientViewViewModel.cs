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
    public class ClientViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SearchCommand { get; private set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Clients));
        }

        public ClientViewViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand);
        }

        public ClientViewModel SelectedClient { get; set; }

        public string Query { get; set; }

        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                return
                    new ObservableCollection<ClientViewModel>
                    (ClientService
                        .Current.Search(Query ?? string.Empty)
                        .Select(c => new ClientViewModel(c)).ToList());
            }
        }

        public void AddClient(Shell s)
        {
            s.GoToAsync("//ClientAddView?clientId=0");
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(Clients));
        }

    }
}
