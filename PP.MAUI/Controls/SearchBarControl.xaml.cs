using System.Windows.Input;

namespace PP.MAUI.Controls;

public partial class SearchBarControl : ContentView
{
    public static readonly BindableProperty SearchButtonTextProperty
        = BindableProperty.Create(nameof(SearchButtonText)
            , typeof(string)
            , typeof(SearchBarControl)
            , string.Empty);

    public static readonly BindableProperty SearchCommandProperty
        = BindableProperty.Create(
            nameof(SearchCommand)
            , typeof(ICommand)
            , typeof(SearchBarControl)
            , default(ICommand));

    public static readonly BindableProperty QueryTextProperty
        = BindableProperty.Create(nameof(QueryText)
            , typeof(string)
            , typeof(SearchBarControl)
            , string.Empty
            , BindingMode.TwoWay);

    public string SearchButtonText
    {
        get => (string)GetValue(SearchButtonTextProperty);
        set => SetValue(SearchButtonTextProperty, value);
    }

    public string QueryText
    {
        get => (string)GetValue(QueryTextProperty);
        set => SetValue(QueryTextProperty, value);
    }

    public ICommand SearchCommand
    {
        get => (ICommand)GetValue(SearchCommandProperty);
        set => SetValue(SearchCommandProperty, value);
    }

    public SearchBarControl()
    {
        InitializeComponent();
        Content.BindingContext = this;
    }
}