namespace Tracing.DataAccess.Dtos; 

public class RefreshToken
{
    public string Token { get; set; } = string.Empty; 
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime ExpiryTime { get; set; }
}