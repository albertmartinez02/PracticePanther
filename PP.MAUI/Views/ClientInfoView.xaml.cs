using PP.Library.Models;
using PP.Library.Services;
using PP.MAUI.ViewModels;

namespace PP.MAUI.Views;

[QueryProperty(nameof(ClientViewId), "clientViewId")]
public partial class ClientInfoView : ContentPage
{
    public int ClientViewId { get; set; }
    public ClientInfoView()
    {
        InitializeComponent();
    }

    private void GoBack(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientPage");
    }

    private void OnArrival(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientViewModel(ClientViewId);
    }
}