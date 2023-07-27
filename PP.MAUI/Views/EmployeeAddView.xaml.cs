using PP.MAUI.ViewModels;
namespace PP.MAUI.Views;

[QueryProperty(nameof(EmployeeId), "employeeId")]
public partial class EmployeeAddView : ContentPage
{
    public int EmployeeId { get; set; }
    public EmployeeAddView()
    {
        InitializeComponent();
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EmployeeViewModel(EmployeeId);
        (BindingContext as EmployeeViewModel).RefreshEmployeeList();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EmployeeView");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//EmployeeView");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }
}