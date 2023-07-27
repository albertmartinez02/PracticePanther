using System.Security.Cryptography.X509Certificates;

namespace PP.MAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void Client_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//ClientPage");
        }

        private void Employee_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//EmployeeView");
        }

        private void TimeClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//TimeView");
        }
    }
}