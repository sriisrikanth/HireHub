using System.Net;
using System.Net.Mail;
using HireHub.Shared.Infrastructure.Interface;
using HireHub.Shared.Infrastructure.Models;

namespace HireHub.Shared.Infrastructure.Service;

public class HireHubEmailService : IHireHubEmailService
{
    private readonly EmailConfig _emailConfig;

    public HireHubEmailService(EmailConfig emailConfig)
    {
        _emailConfig = emailConfig;
    }

    public async Task<EmailStatus> SendEmailAsync(string fromEmail, string toEmail,
        string subject, string body)
    {
        return await SendEmailAsync(fromEmail, [toEmail], subject, body, null!, null!, null!);
    }

    public async Task<EmailStatus> SendEmailAsync(string fromEmail, string toEmail,
        string subject, string body, Attachment attachment)
    {
        return await SendEmailAsync(fromEmail, [toEmail], subject, body, null!, null!, [attachment]);
    }

    public async Task<EmailStatus> SendEmailAsync(string fromEmail, string toEmail,
        string subject, string body, Attachment[] attachments)
    {
        return await SendEmailAsync(fromEmail, [toEmail], subject, body, null!, null!, attachments);
    }

    public async Task<EmailStatus> SendEmailAsync(string fromEmail, string[] toEmails,
        string subject, string body)
    {
        return await SendEmailAsync(fromEmail, toEmails, subject, body, null!, null!, null!);
    }

    public async Task<EmailStatus> SendEmailAsync(string fromEmail, string[] toEmails,
        string subject, string body, Attachment attachment)
    {
        return await SendEmailAsync(fromEmail, toEmails, subject, body, null!, null!, [attachment]);
    }

    public async Task<EmailStatus> SendEmailAsync(string fromEmail, string[] toEmails,
        string subject, string body, Attachment[] attachments)
    {
        return await SendEmailAsync(fromEmail, toEmails, subject, body, null!, null!, attachments);
    }

    public async Task<EmailStatus> SendEmailAsync(string fromEmail, string[] toEmails,
        string subject, string body, string[] ccs, string[] bccs, Attachment[] attachments)
    {
        return await SendEmailAsync(fromEmail, null!, toEmails, subject, body, ccs, bccs, attachments);
    }

    // with display name parameter

    public async Task<EmailStatus> SendEmailAsync(string fromEmail, string displayName, string toEmail,
        string subject, string body)
    {
        return await SendEmailAsync(fromEmail, displayName, [toEmail], subject, body, null!, null!, null!);
    }

    public async Task<EmailStatus> SendEmailAsync(string fromEmail, string displayName, string toEmail,
        string subject, string body, Attachment attachment)
    {
        return await SendEmailAsync(fromEmail, displayName, [toEmail], subject, body, null!, null!, [attachment]);
    }

    public async Task<EmailStatus> SendEmailAsync(string fromEmail, string displayName, string toEmail,
        string subject, string body, Attachment[] attachments)
    {
        return await SendEmailAsync(fromEmail, displayName, [toEmail], subject, body, null!, null!, attachments);
    }

    public async Task<EmailStatus> SendEmailAsync(string fromEmail, string displayName, string[] toEmails,
        string subject, string body)
    {
        return await SendEmailAsync(fromEmail, displayName, toEmails, subject, body, null!, null!, null!);
    }

    public async Task<EmailStatus> SendEmailAsync(string fromEmail, string displayName, string[] toEmails,
        string subject, string body, Attachment attachment)
    {
        return await SendEmailAsync(fromEmail, displayName, toEmails, subject, body, null!, null!, [attachment]);
    }

    public async Task<EmailStatus> SendEmailAsync(string fromEmail, string displayName, string[] toEmails,
        string subject, string body, Attachment[] attachments)
    {
        return await SendEmailAsync(fromEmail, displayName, toEmails, subject, body, null!, null!, attachments);
    }

    public async Task<EmailStatus> SendEmailAsync(string fromEmail, string displayName, string[] toEmails, 
        string subject, string body, string[] ccs, string[] bccs, Attachment[] attachments)
    {
        if (string.IsNullOrEmpty(fromEmail)) return new EmailStatus()
        { SendStatus = false, Message = "From email address not provided" };
        if (toEmails.Length == 0) return new EmailStatus()
        { SendStatus = false, Message = "Recipient email address not provided" };

        var smtpClient = new SmtpClient(_emailConfig.Client)
        {
            Port = 587,
            Credentials = new NetworkCredential(_emailConfig.Username, _emailConfig.Password),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(fromEmail, displayName),
            Subject = subject ?? string.Empty,
            Body = body ?? string.Empty,
            IsBodyHtml = false
        };
        foreach (var toEmail in toEmails)
            mailMessage.To.Add(toEmail);

        if (ccs != null)
            foreach (var cc in ccs)
                mailMessage.CC.Add(cc);
        if (bccs != null)
            foreach (var bcc in bccs)
                mailMessage.Bcc.Add(bcc);
        if (attachments != null)
            foreach (var attachment in attachments)
                mailMessage.Attachments.Add(attachment);

        await smtpClient.SendMailAsync(mailMessage);

        return new EmailStatus() 
        { SendStatus = true, Message = "Email sent successfully" };
    }
}
