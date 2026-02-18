using System.Net.Mail;
using HireHub.Shared.Infrastructure.Models;

namespace HireHub.Shared.Infrastructure.Interface;

public interface IHireHubEmailService
{
    Task<EmailStatus> SendEmailAsync(string fromEmail, string toEmail,
        string subject, string body);
    Task<EmailStatus> SendEmailAsync(string fromEmail, string toEmail,
        string subject, string body, Attachment attachment);
    Task<EmailStatus> SendEmailAsync(string fromEmail, string toEmail,
        string subject, string body, Attachment[] attachments);
    Task<EmailStatus> SendEmailAsync(string fromEmail, string[] toEmails,
        string subject, string body);
    Task<EmailStatus> SendEmailAsync(string fromEmail, string[] toEmails,
        string subject, string body, Attachment attachment);
    Task<EmailStatus> SendEmailAsync(string fromEmail, string[] toEmails,
        string subject, string body, Attachment[] attachments);
    Task<EmailStatus> SendEmailAsync(string fromEmail, string[] toEmails,
        string subject, string body, string[] ccs, string[] bccs, Attachment[] attachments);

    // with display name parameter

    Task<EmailStatus> SendEmailAsync(string fromEmail, string displayName, string toEmail,
        string subject, string body);
    Task<EmailStatus> SendEmailAsync(string fromEmail, string displayName, string toEmail,
        string subject, string body, Attachment attachment); 
    Task<EmailStatus> SendEmailAsync(string fromEmail, string displayName, string toEmail,
        string subject, string body, Attachment[] attachments);
    Task<EmailStatus> SendEmailAsync(string fromEmail, string displayName, string[] toEmails,
        string subject, string body);
    Task<EmailStatus> SendEmailAsync(string fromEmail, string displayName, string[] toEmails,
        string subject, string body, Attachment attachment);
    Task<EmailStatus> SendEmailAsync(string fromEmail, string displayName, string[] toEmails,
        string subject, string body, Attachment[] attachments);
    Task<EmailStatus> SendEmailAsync(string fromEmail, string displayName, string[] toEmails,
        string subject, string body, string[] ccs, string[] bccs, Attachment[] attachments);
}
