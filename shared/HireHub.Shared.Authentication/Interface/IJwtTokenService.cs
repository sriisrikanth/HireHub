using System.Security.Claims;

namespace HireHub.Shared.Authentication.Interface;

public interface IJwtTokenService
{
    /// <summary>
    /// Generates a JWT token for a given userId and role.
    /// </summary>
    string GenerateToken(string userId, string role);

    /// <summary>
    /// Validates a JWT token and returns userId if valid.
    /// </summary>
    List<Claim>? ValidateToken(string token);
}
