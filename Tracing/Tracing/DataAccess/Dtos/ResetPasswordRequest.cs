using System.ComponentModel.DataAnnotations;

namespace Tracing.DataAccess.Dtos
{
    public class ResetPasswordRequest
    {
        public string Token { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ComfirmPassword { get; set; } = string.Empty;
    }
}
