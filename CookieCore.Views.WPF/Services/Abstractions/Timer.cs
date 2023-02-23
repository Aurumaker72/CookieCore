using System.Windows.Threading;
using CookieCore.Services.Abstractions;

namespace CookieCore.Views.WPF.Services.Abstractions;

public class Timer : ITimer
{
    private readonly DispatcherTimer _dispatcherTimer;

    public Timer(DispatcherTimer dispatcherTimer)
    {
        _dispatcherTimer = dispatcherTimer;
    }

    public bool IsRunning
    {
        get => _dispatcherTimer.IsEnabled;
        set => _dispatcherTimer.IsEnabled = value;
    }
}