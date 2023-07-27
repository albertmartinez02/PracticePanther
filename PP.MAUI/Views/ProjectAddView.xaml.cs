using PP.MAUI.ViewModels;
namespace PP.MAUI.Views;

[QueryProperty(nameof(cid), "cid")] //Used when adding a project
[QueryProperty(nameof(pid), "pid")] //Used when editing a project
public partial class ProjectAddView : ContentPage
{
    public int cid { get; set; }
    public int pid { get; set; }
    public ProjectAddView()
    {
        InitializeComponent();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ClientAddView?clientId={(BindingContext as ProjectViewModel).Model.ClientId}");
    }

    private void OnArrival(object sender, NavigatedToEventArgs e)
    {
        if (pid != 0)
        {
            BindingContext = new ProjectViewModel(pid, true);
        }
        else
        {
            BindingContext = new ProjectViewModel(cid);
        }
    }

}