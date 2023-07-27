using PP.MAUI.ViewModels;
namespace PP.MAUI.Views;
using System.ComponentModel;


public partial class ClientPage : ContentPage
{
    public ClientPage()
    {
        InitializeComponent();
        BindingContext = new ClientViewViewModel();
    }

    private void AddClient(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).AddClient(Shell.Current);
    }

    private void GoBackToMain(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshView();
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshView();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshView();
    }
}