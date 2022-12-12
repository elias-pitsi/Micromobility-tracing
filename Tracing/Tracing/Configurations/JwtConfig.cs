namespace Tracing.Configurations;

public class JwtConfig
{
    public string Secret { get; set; } = string.Empty;
    public TimeSpan ExpiryMinutes { get; set; }  
    public string Issuer {get; set; } = string.Empty;
    public string Audience { get; set; } = String.Empty;
    public string Token { get; set; } = String.Empty;
}