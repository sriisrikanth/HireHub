using System.Text;
using System.Text.Json;
using HireHub.Shared.Infrastructure.Interface;
using HireHub.Shared.Infrastructure.Models;

namespace HireHub.Shared.Infrastructure.Service;

public class AzureEmailService : IAzureEmailService
{
    private readonly AzureLogicApp _azureLogicApp;

    public AzureEmailService(AzureLogicApp azureLogicApp)
    {
        _azureLogicApp = azureLogicApp;
    }

    public async Task<EmailStatus> SendEmailAsync(Email email, IHttpClientFactory httpClientFactory)
    {
        var jsonPayload = new
        {
            to = email.To,
            subject = email.Subject,
            email_body = email.Body
        };

        var jsonContent = new StringContent(JsonSerializer.Serialize(jsonPayload), Encoding.UTF8, "application/json");

        var client = httpClientFactory.CreateClient();

        var response = await client.PostAsync(_azureLogicApp.Url, jsonContent);

        if (response.IsSuccessStatusCode)
            return new EmailStatus { SendStatus = true, Message = "Logic App Invoked Successfully!" };

        return new EmailStatus { SendStatus = false, Message = "Logic App Invoke Failed" };
    }
}