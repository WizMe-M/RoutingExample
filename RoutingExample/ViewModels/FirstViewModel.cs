using System;
using ReactiveUI;

namespace RoutingExample.ViewModels;

public class FirstViewModel : ViewModelBase, IRoutableViewModel
{
    // Reference to IScreen that owns the routable view model.
    public IScreen HostScreen { get; }

    // Unique identifier for the routable view model.
    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString();

    public FirstViewModel(IScreen hostScreen) => HostScreen = hostScreen;
}