using PP.MAUI.ViewModels;

namespace PP.MAUI.Views;

[QueryProperty(nameof(TimeID) , "timeID")]
public partial class BillAddView : ContentPage
{
	public int TimeID { get; set; }
	public BillAddView()
	{
		InitializeComponent();
	}

    private void OnArrival(object sender, NavigatedToEventArgs e)
    {
		BindingContext = new BillViewModel(TimeID);
    }

    private void CreateClicked(object sender, EventArgs e)
    {
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