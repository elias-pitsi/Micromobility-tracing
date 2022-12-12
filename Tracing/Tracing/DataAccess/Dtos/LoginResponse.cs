namespace Tracing.DataAccess.Dtos; 

public class LoginResponse
{
    public string? Token { get; set; }
    public string? OwnerId { get; set; } 
    public string? Email { get; set; }
    public string? returnMessage { get; set; } 
}