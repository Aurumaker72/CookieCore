namespace CookieCore;

/// <inheritdoc cref="Game" />
public partial class Game
{
    /// <summary>
    ///     A default game save
    /// </summary>
    public static Game Default => new()
    {
        Buildings = new Building[]
        {
            new()
            {
                Identifier = "Cursor",
                BasePrice = 15,
                BaseCookiesPerSecond = 0.1
            },
            new()
            {
                Identifier = "Grandma",
                BasePrice = 100,
                BaseCookiesPerSecond = 1
            },
            new()
            {
                Identifier = "Farm",
                BasePrice = 1265,
                BaseCookiesPerSecond = 8
            }
        }
    };
}