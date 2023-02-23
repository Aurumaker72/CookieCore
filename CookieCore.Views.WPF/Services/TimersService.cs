using System;
using System.Windows.Threading;
using CookieCore.Services;
using CookieCore.Services.Abstractions;
using CookieCore.Views.WPF.Services.Abstractions;

namespace CookieCore.Views.WPF.Services;

public class TimersService : ITimersService
{
    private readonly Dispatcher _dispatcher;

    public TimersService(Dispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    public ITimer Create(TimeSpan interval, Action callback)
    {
        var timer = new DispatcherTimer(interval, DispatcherPriority.Normal, (sender, args) => callback(), _dispatcher);

        return new Timer(timer);
    }
}