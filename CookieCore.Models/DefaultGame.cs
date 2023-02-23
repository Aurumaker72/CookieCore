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
                Identifier = "Extractor",
                BasePrice = 5,
                BaseCookiesPerSecond = 1
            }
        }
    };
}