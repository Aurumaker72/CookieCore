using CookieCore.Services.Abstractions;

namespace CookieCore.Services;

/// <summary>
/// Represents a contract for a timer creation service
/// </summary>
public interface ITimersService
{
    /// <summary>
    /// Creates a timer with the specified parameters
    /// </summary>
    /// <param name="interval">The interval between invocations of <paramref name="callback"/></param>
    /// <param name="callback">The action to be invoked</param>
    /// <returns>A running timer with the specified parameters</returns>
    public ITimer Create(TimeSpan interval, Action callback);
}