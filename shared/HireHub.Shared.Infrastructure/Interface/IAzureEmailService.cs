using HireHub.Shared.Infrastructure.Models;

namespace HireHub.Shared.Infrastructure.Interface;

public interface IAzureEmailService
{
    Task<EmailStatus> SendEmailAsync(Email email, IHttpClientFactory httpClientFactory);
}