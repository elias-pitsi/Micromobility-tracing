using System.ComponentModel.DataAnnotations;

namespace Tracing.DataAccess.Dtos;

public class OwnerRegistrationDto
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
}