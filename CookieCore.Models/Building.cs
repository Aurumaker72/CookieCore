using Newtonsoft.Json;

namespace CookieCore;

/// <summary>
/// Represents the a building state as a plain .NET object
/// </summary>
[JsonObject(MemberSerialization.OptOut)]
public class Building
{
    public string Identifier;
    public int Amount;
    public double Price;
    public double CookiesPerSecond;
}