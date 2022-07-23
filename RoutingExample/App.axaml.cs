using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using RoutingExample.Services;
using RoutingExample.ViewModels;
using RoutingExample.Views;

namespace RoutingExample;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    public override void OnFrameworkInitializationCompleted()
    {
        var suspension = new AutoSuspendHelper(ApplicationLifetime!);
        RxApp.SuspensionHost.CreateNewAppState = () => new MainWindowViewModel();
        RxApp.SuspensionHost.SetupDefaultSuspendResume(new SuspensionDriver("appstate.json"));
        suspension.OnFrameworkInitializationCompleted();
        var state = RxApp.SuspensionHost.GetAppState<MainWindowViewModel>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow { DataContext = state };
        }

        base.OnFrameworkInitializationCompleted();
    }
}