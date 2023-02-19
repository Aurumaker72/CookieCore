using Newtonsoft.Json;

namespace CookieCore;

/// <summary>
///     Represents the game state as a plain .NET object
/// </summary>
[JsonObject(MemberSerialization.OptOut)]
public class Game
{
    private Game() {}
    
    public double Cookies;
    public Building[] Buildings;

    public static Game Default => new()
    {
        Buildings = new Building[]
        {
            new()
            {
                Identifier = "Extractor",
                Price = 5,
                CookiesPerSecond = 1
            }
        }
    };
}