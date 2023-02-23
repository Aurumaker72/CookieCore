using Newtonsoft.Json;

namespace CookieCore;

/// <summary>
///     Represents the game state as a plain .NET object
/// </summary>
[JsonObject(MemberSerialization.OptOut)]
public partial class Game
{
    /// <summary>
    ///     The available buildings
    /// </summary>
    public Building[] Buildings;

    /// <summary>
    ///     The amount of cookies
    /// </summary>
    public double Cookies;

    /// <remarks>
    ///     Manual invocation of the constructor is disallowed
    /// </remarks>
    private Game()
    {
    }
}