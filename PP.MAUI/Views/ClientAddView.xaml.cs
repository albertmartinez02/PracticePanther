using PP.MAUI.ViewModels;
using PP.Library.Models;

namespace PP.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ClientAddView : ContentPage
{
    public int ClientId { get; set; }

    public ClientAddView()
    {
        InitializeComponent();
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientViewModel(ClientId);
        (BindingContext as ClientViewModel).RefreshProjects();
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OKClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//ClientPage");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientPage");
    }

    private void AddProjectClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).AddProject();
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).RefreshProjects();
    }
}