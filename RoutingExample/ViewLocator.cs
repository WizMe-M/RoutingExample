using System;
using ReactiveUI;

namespace RoutingExample;

public class ViewLocator : IViewLocator
{
    public IViewFor? ResolveView<T>(T viewModel, string? contract = null)
    {
        var name = viewModel!.GetType().FullName!.Replace("ViewModel", "View");
        var type = Type.GetType(name);
        if (type != null)
        {
            return Activator.CreateInstance(type) as IViewFor;
        }

        return null;
    }
}