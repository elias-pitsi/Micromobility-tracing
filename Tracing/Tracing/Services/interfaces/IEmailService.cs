using Tracing.DataAccess.Dtos;

namespace Tracing.Services.interfaces
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
