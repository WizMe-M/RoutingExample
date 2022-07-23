using System.Runtime.Serialization;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace RoutingExample.ViewModels;

[DataContract]
public class FirstViewModel : ViewModelBase, IRoutableViewModel
{
    public IScreen HostScreen { get; }
    public string UrlPathSegment => "/first_view";

    [DataMember]
    [Reactive]
    public string SearchText { get; set; }

    public FirstViewModel(IScreen hostScreen) => HostScreen = hostScreen;
}