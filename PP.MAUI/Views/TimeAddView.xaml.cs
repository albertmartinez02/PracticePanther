using PP.MAUI.ViewModels;

namespace PP.MAUI.Views;

public partial class TimeAddView : ContentPage
{
    public TimeAddView()
    {
        InitializeComponent();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//TimeView");
    }

    private void OnArrival(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new TimeViewModel();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//TimeView");
    }
}