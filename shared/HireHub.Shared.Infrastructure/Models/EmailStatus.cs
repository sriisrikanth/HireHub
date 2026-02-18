namespace HireHub.Shared.Infrastructure.Models;

public class EmailStatus
{
    public bool SendStatus { get; set; }
    public string Message { get; set; } = string.Empty;
}