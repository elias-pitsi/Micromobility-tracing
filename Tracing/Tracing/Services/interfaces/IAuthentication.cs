using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;

namespace Tracing.Services.interfaces;

public interface IAuthentication
{
    Task<string> Registration(OwnerRegistrationDto request);
    Task<LoginResponse> Login(OwnerLoginDto request);
    Task<string> ForgotPassword(string email);
    Task<string> ResetPassword(ResetPasswordRequest request);
    Task<string> Verify(string token);
}