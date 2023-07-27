using PP.MAUI.ViewModels;

namespace PP.MAUI.Views;

[QueryProperty(nameof(TimeID), "timeID")]
public partial class TimeEdit : ContentPage
{

    public int TimeID { get; set; }
    public TimeEdit()
    {
        InitializeComponent();
    }

    private void OnArrival(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new TimeViewModel(TimeID);
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//TimeView");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//TimeView");
    }

    private void OnLeave(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
}