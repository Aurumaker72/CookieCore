namespace CookieCore.Services;

/// <summary>
/// Represents a contract for a timer
/// </summary>
public interface ITimer
{
    /// <summary>
    /// Whether the timer is actively invoking the callback
    /// </summary>
    public bool IsRunning { get; set; }
}