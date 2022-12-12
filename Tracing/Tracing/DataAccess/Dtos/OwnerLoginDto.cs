using System.ComponentModel.DataAnnotations;

namespace Tracing.DataAccess.Dtos;

public class OwnerLoginDto 
{
public string email { get; set; } = string.Empty;
public string password { get; set; } = string.Empty;
}
