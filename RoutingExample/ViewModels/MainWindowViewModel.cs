using System.Reactive;
using System.Runtime.Serialization;
using ReactiveUI;

namespace RoutingExample.ViewModels;

[DataContract]
public class MainWindowViewModel : ViewModelBase, IScreen
{
    [DataMember]
    public RoutingState Router { get; } = new();
        
    [IgnoreDataMember]
    public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

    [IgnoreDataMember]
    public ReactiveCommand<Unit, Unit> GoBack => Router.NavigateBack;

    [IgnoreDataMember]
    public string Default { get; } = "This is a default content for routing";

    public MainWindowViewModel()
    {
        GoNext = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new FirstViewModel(this))
        );
    }
}