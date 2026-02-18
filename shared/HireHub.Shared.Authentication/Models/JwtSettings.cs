namespace HireHub.Shared.Authentication.Models;

public class JwtSettings
{
    public string Secret { get; set; } = null!;
    public string[] Issuer { get; set; } = null!;
    public string[] Audiens { get; set; } = null!;
    public int ExpireInHours { get; set; } = 1;
}
