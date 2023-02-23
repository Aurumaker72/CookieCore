using Newtonsoft.Json;

namespace CookieCore;

/// <summary>
///     Represents the a building state as a plain .NET object
/// </summary>
[JsonObject(MemberSerialization.OptOut)]
public class Building
{
    /// <summary>
    ///     The total count of buildings
    /// </summary>
    public int Amount;

    /// <summary>
    ///     The initial cookies per second for 1 unscaled building
    /// </summary>
    public double BaseCookiesPerSecond;

    /// <summary>
    ///     The initial unscaled price
    /// </summary>
    public double BasePrice;

    /// <summary>
    ///     The unique identifier, which should be used for localization
    /// </summary>
    public string Identifier;
}