namespace BuberDinner.Infrastructure.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    
    public string Secret { get; init; } = null!;
    public int ExpiryMinutes { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
    
    /***
     * In C# 9.0 and later versions, the init accessor is used in property declarations
     * to allow the property to be set during object initialization but then become read-only
     * after that initialization. This is particularly useful for scenarios where you
     * want to set the initial value of a property upon object creation and then prevent
     * further changes to that property.
     */
}

