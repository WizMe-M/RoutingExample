using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using RoutingExample.ViewModels;

namespace RoutingExample.Views;

public partial class FirstView : ReactiveUserControl<FirstViewModel>
{
    public FirstView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}