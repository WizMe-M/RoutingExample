using System;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using Newtonsoft.Json;
using ReactiveUI;

namespace RoutingExample.Services;

public class SuspensionDriver : ISuspensionDriver
{
    private readonly string _file;

    private readonly JsonSerializerSettings _settings = new()
    {
        TypeNameHandling = TypeNameHandling.All
    };

    public SuspensionDriver(string file) => _file = file;

    public IObservable<object> LoadState()
    {
        var json = File.ReadAllText(_file);
        var state = JsonConvert.DeserializeObject<object>(json, _settings);
        return Observable.Return(state)!;
    }

    public IObservable<Unit> SaveState(object state)
    {
        var json = JsonConvert.SerializeObject(state, Formatting.Indented, _settings);
        File.WriteAllText(_file, json);
        return Observable.Return(Unit.Default);
    }

    public IObservable<Unit> InvalidateState()
    {
        if (File.Exists(_file)) File.Delete(_file);
        return Observable.Return(Unit.Default);
    }
}